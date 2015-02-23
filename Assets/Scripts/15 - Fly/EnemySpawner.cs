using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject gameObject;
	public float moveSpeed;
	public float startTime;
	public float secondsBetweenSpawn;

	private float timeLeftUntilSpawn;
	private float moveDistance;
	private float time;

	public void Create(){
		transform.position = new Vector3 (
			GameManager.instance.boundaries.xMax + 2,
			Random.Range (
				GameManager.instance.boundaries.yMin + 2,
				GameManager.instance.boundaries.yMax - 2),
			0);
		moveDistance = GameManager.instance.boundaries.yDistance () - 2;
		timeLeftUntilSpawn = 0;

		time = startTime;
	}

	protected void Spawn (){
		GameObject go = Instantiate (gameObject) as GameObject;
		go.transform.position = transform.position;
		GameManager.instance.enemiesManager.enemies.Add (go);
	}

	public virtual void SpawnMachine(){
		transform.position = new Vector3 (
			transform.position.x, 
			Mathf.PingPong (Time.time * moveSpeed, moveDistance*2) - moveDistance, 
			transform.position.z);

		
		if (timeLeftUntilSpawn >= secondsBetweenSpawn) {
			time = Time.time;
			Spawn();
		}

		timeLeftUntilSpawn = Time.time - time;
	}




}
