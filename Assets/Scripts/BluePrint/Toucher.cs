using UnityEngine;
using System.Collections;

public class Toucher : MonoBehaviour {
	public GameObject Explosion;
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {			Destroy (gameObject);
			Instantiate(Explosion, other.transform.position, other.transform.rotation); 
			GameObject.FindWithTag ("GameController").GetComponent<GameControlerTaches>().SupprimerTaches(); //on supprime une étoile
		}
		
	}

}
