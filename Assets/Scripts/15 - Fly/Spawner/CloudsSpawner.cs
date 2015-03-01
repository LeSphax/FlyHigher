using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudsSpawner : MonoBehaviour {

	public GameObject[] gos;

	public Boundary boundary;
	private List <GameObject> gosList;
	private float moveSpeed = 5f;
	private float moveDistance;
	private float timeLeftUntilSpawn = 0f;
	private float startTime = 0f;
	private float secondsBetweenSpawn = 2f;

	public void Start (){
		if (GameManager.instance != null)
			boundary = GameManager.instance.boundaries;
		transform.position = new Vector3( boundary.xMax + 2, 0, 0);
		moveDistance = boundary.yDistance () - 2;
		gosList = new List<GameObject> ();
		Spawn ();
	}
	
	protected virtual void Spawn (){
		GameObject obj = Instantiate(gos[Random.Range(0, gos.Length)]) as GameObject;
		
		gosList.Add (obj);
		
		obj.transform.position = transform.position;

		Cloud c = obj.GetComponent<Cloud>();
		c.Create ();
	}
	
	private void DestroyObject (GameObject obj){
		gosList.Remove (obj);
		Destroy (obj);
	}

	public void DestroyAll (){
		while (gosList.Count > 0) {
			Destroy (gosList[0]);
		}
	}

	public void Update (){
		for (int i = 0; i < gosList.Count; i++) {
			GameObject go = gosList[i];
			Cloud c = go.GetComponent<Cloud>();
			if (c.transform.position.x < boundary.xMin - (boundary.xDistance()/2)){
				i--;
				DestroyObject(go);
			}
			else go.GetComponent<Cloud>().Move();
		}
		transform.position = new Vector3 (transform.position.x, Mathf.PingPong (Time.time * moveSpeed, moveDistance*2) - moveDistance, 0); 

		if (timeLeftUntilSpawn >= secondsBetweenSpawn) {
			startTime = Time.time;
			timeLeftUntilSpawn = 0;
			Spawn();
		}
		timeLeftUntilSpawn = Time.time - startTime;
	}

}
