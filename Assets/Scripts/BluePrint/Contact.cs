using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {
	public GameObject Explosion;
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Point") { //on récupere un objectifs
			Destroy (other.gameObject);
			GameObject.FindWithTag ("GameController").GetComponent<GameControlerScript>().ObjectifsRamasser();

		}
		if (other.tag == "Obstacle") {
			Destroy (other.gameObject);
			Instantiate(Explosion, other.transform.position, other.transform.rotation); 
			GameObject.FindWithTag ("GameController").GetComponent<GameControlerScript>().SuppEtoile(); //on supprime une étoile

		}
	}

}
