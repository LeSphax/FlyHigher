using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManager : MonoBehaviour {
	[HideInInspector] public List <GameObject> enemies;

	public GameObject eagleSpawner;
	public GameObject alienSpawner;

	public void Init (){
		enemies = new List<GameObject>();
		Instantiate (eagleSpawner);
		eagleSpawner.GetComponent<EnemySpawner> ().Create();
		Instantiate (alienSpawner);
		alienSpawner.GetComponent<EnemySpawner> ().Create ();
	}

	public void DestroyEnemy(GameObject enemy){
		enemies.Remove (enemy);
		Destroy (enemy);
	}

	public void DestroyEnemy(Enemy enemy){
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies[i].GetComponent<Enemy>() == enemy) {
				DestroyEnemy(enemies[i]);
			}
		}
	}

	public void SpawnEnemies (){
		eagleSpawner.GetComponent<EnemySpawner>().SpawnMachine();
		alienSpawner.GetComponent<EnemySpawner>().SpawnMachine();
	}

	public void MoveEnemies(){
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies[i].transform.position.x < 
			    GameManager.instance.boundaries.xMin - (GameManager.instance.boundaries.xDistance()/2)){
			    DestroyEnemy(enemies[i]);
				i--;
			} else {
				RaycastHit2D hit = new RaycastHit2D();
				bool b = enemies[i].GetComponent<Enemy> ().MoveEnemy (out hit);
				if(hit.transform != null){
					//Get a component reference to the component of type T attached to the object that was hit
					Player hitComponent = hit.transform.GetComponent <Player> ();
				
					//If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
					if(!b && hitComponent != null){
						DestroyEnemy(enemies[i]);
						i--;
						hitComponent.Hit();
					} else {
						Enemy hitComponentBis = hit.transform.GetComponent <Enemy> ();

						if (!b && hitComponentBis != null){
							DestroyEnemy(enemies[i]);
							i--;
						}
					}
				}
			}
		}
	}
}
