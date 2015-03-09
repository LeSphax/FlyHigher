using UnityEngine;
using System.Collections;

public class GameControler : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public float startWait;
	public float waveWait;
	private bool gameOver;
	private GameObject jeu;
	private bool nouvelleVague;



	/*---------------------------------*/
	/* controle le déroulement du jeu*	/
	/*--------------------------------*/



	/*lancer au début du jeu*/
	void Start()
	{
		gameOver = true;
		nouvelleVague = false;
		StartCoroutine(SpawnWave());
	}



	/* fonction qui fait apparaitre les vagues des enemies */
	IEnumerator SpawnWave(){
		yield return new WaitForSeconds (3);
		while (gameOver) {
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-3,10), spawnValues.z);
				//Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition,Quaternion.identity);
				yield return new WaitForSeconds(waveWait);
			if(nouvelleVague){
				//detruire tout les avions
				waveWait = waveWait * 0.80f;
				nouvelleVague=false;
				yield return new WaitForSeconds(3);//attend 3seconde
			}
		}

	}

	//fonction de fin du jeu
	public void FinJeu(){
		gameOver = false;
	}

	//reinitialise la vague et replace le joueur
	public  void NouvelleVague(){
		nouvelleVague = true;
		destructionAvion();

	}







	//detruit toytut les avions présent sur la care
	public void destructionAvion(){
		 Object[] respawns = GameObject.FindGameObjectsWithTag("Enemies");
		
			foreach (Object respawn in respawns) {
				Destroy(respawn);
			}
	}
	
}
