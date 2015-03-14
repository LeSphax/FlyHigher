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
	public GameObject gameUi;
	public int nbeLevel;
	public GUIText texte;

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
		yield return new WaitForSeconds (0);
		while (gameOver) {
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-3,10), spawnValues.z);
				//Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition,Quaternion.identity);
				yield return new WaitForSeconds(waveWait);
			if(nouvelleVague){
				texte.enabled=true;
				//detruire tout les avions
				waveWait = waveWait * 0.80f;
				nouvelleVague=false;
				GameObject.FindWithTag ("Player").GetComponent<PlayerControler> ().waitNewWave ();
				yield return new WaitForSeconds(3);//attend 3seconde
				GameObject.FindWithTag ("Player").GetComponent<PlayerControler> ().ok ();

			}

		}


	}

	
	//fonction de fin du jeu
	public void FinJeu(int vie){
		gameOver = false;
		gameUi.SendMessage ("GameEnded", vie);
		//gameUi.SendMessage ("GameEnded",GameObject.FindWithTag ("Player").GetComponent<DestructionByContact> ().vie);
		//	DestructionByContact vie=GameObject.FindWithTag ("Player").GetComponent<DestructionByContact> ().vie;
		//	vie.vie
		
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




	//detruit toytut les avions présent sur la care
	public void destructionAvion(){
		 Object[] respawns = GameObject.FindGameObjectsWithTag("Enemies");
		
			foreach (Object respawn in respawns) {
				Destroy(respawn);
			}
	}
	
}
