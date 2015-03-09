using UnityEngine;
using System.Collections;

public class NewWave : MonoBehaviour {

	private GameControler jeu;
	
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			jeu=gameControllerObject.GetComponent<GameControler>();
		}
		if (gameControllerObject == null) {
			Debug.Log("pas trouver");
		}
		
	}

	void OnTriggerExit(Collider other){
		GameObject avion = GameObject.FindWithTag ("Enemies");
		if (other.tag == "Player") {
			jeu.NouvelleVague(); //appeler new wave
			if(avion!=null){
				Destroy(avion); //detruit les eventuelle avions
				//Destroy(o);
			}
		}

	}
		
}
