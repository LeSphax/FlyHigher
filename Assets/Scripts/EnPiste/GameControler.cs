using UnityEngine;
using System.Collections;

public class GameControler : MonoBehaviour {

	public GameObject hazard;
	public GameObject hazard2;

	public Vector3 spawnValues;
	public float startWait;
	public float waveWait;
	private bool gameOver;
	private GameObject jeu;
	private bool nouvelleVague;
	public GameObject gameUi;
	public int nbeLevel;
	public GameObject texte;


	/*---------------------------------*/
	/* controle le déroulement du jeu*	/
	/*--------------------------------*/



	/*lancer au début du jeu*/
	void Start()
	{
		texte.SetActive(false);
		gameOver = true;
		nouvelleVague = false;
		StartCoroutine(SpawnWave());
	}



	/* fonction qui fait apparaitre les vagues des enemies */
	IEnumerator SpawnWave(){
		int nbeEnemies = 0;
		yield return new WaitForSeconds (0);
		while (gameOver) {
			float y=Random.Range (-12,9);

				//Quaternion spawnRotation = Quaternion.identity;
			if(nbeEnemies==5){
				Vector3 spawnPosition = new Vector3 (spawnValues.x,y,0);
				Instantiate (hazard2, spawnPosition,Quaternion.identity); //fait apparaitre un avion
				nbeEnemies=0;
			}else{
				Vector3 spawnPosition = new Vector3 (spawnValues.x,y, spawnValues.z);
				Instantiate (hazard, spawnPosition,Quaternion.identity); //fait apparaitre un chariot
				nbeEnemies++;
			}


				yield return new WaitForSeconds(waveWait);
			if(nouvelleVague){
				texte.SetActive(true);
				waveWait = waveWait * 0.60f;
				nouvelleVague=false;
				GameObject.FindWithTag ("Player").GetComponent<PlayerControler>().moveUp=0;
				yield return new WaitForSeconds(2);//attend 3seconde
				//GameObject.FindWithTag ("Player").GetComponent<PlayerControler> ().ok ();
				texte.SetActive(false);
			}
		}
	}

	
	//fonction de fin du jeu
	public void FinJeu(int vie){
		gameOver = false;
		gameUi.SendMessage ("GameEnded", vie);
	}
	
	//reinitialise la vague et replace le joueur
	public  void NouvelleVague(){
		nouvelleVague = true;
		destructionAvion();
		nbeLevel--;
		if (nbeLevel <= 0) { //fin du jeu 
			FinJeu(GameObject.FindWithTag ("Player").GetComponent<DestructionByContact> ().vie);
		}

	}




	//detruit tout les avions présent sur la care
	public void destructionAvion(){
		 Object[] respawns = GameObject.FindGameObjectsWithTag("Enemies");
			foreach (Object respawn in respawns) {
				Destroy(respawn);
			}
	}
	
}
