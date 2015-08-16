using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyGameObject;
	public float moveSpeed;

	private float startTime;
	private float secondsBetweenSpawn;
	private float minSecondsBetweenSpawn;
	private float timeLeftUntilSpawn;
	private float moveDistance;
	private float time;
	private float speed;

	public void Create(float sbs, float st, float s, float minSbs){
		secondsBetweenSpawn = sbs;
		startTime = Time.time + st;
		speed = s;
		minSecondsBetweenSpawn = minSbs;
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
		secondsBetweenSpawn = Mathf.Clamp(secondsBetweenSpawn - 0.1f, minSecondsBetweenSpawn, 10f);
		speed = Mathf.Clamp (speed + 0.2f, 0f, 10f);
		GameObject go = Instantiate (enemyGameObject) as GameObject;
		go.GetComponent<Enemy> ().Create (speed);
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
