using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {
	public GameObject Explosion;
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Point") { //on récupere un objectifs
			Vector3 v=new Vector3(1.0f,1.0f,0.0f);
			GameObject.FindWithTag ("GameController").GetComponent<GameControlerScript>().ObjectifsRamasser(); //ramasse l'objectifs
			GameObject.FindWithTag ("Player").GetComponent<PlayeurControlleur>().NouvelleLigne(other.transform.position);//rajoute un point de depart de traits
			Destroy (other.gameObject);

		}
		if (other.tag == "Obstacle") {
			Destroy (other.gameObject);
			Instantiate(Explosion, other.transform.position, other.transform.rotation); 
			GameObject.FindWithTag ("GameController").GetComponent<GameControlerScript>().SuppEtoile(); //on supprime une étoile

		}
	}

}
