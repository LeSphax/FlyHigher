using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {
	public GameObject Explosion;
	public GameObject Arriver;
	private bool first=true;

	void OnTriggerEnter(Collider other){

		if (other.tag == "Point") { //on récupere un objectifs
			//Vector3 v=new Vector3(1.0f,1.0f,0.0f);
			GameObject.FindWithTag ("GameController").GetComponent<GameControlerScript>().ObjectifsRamasser(); //ramasse l'objectifs
			GameObject.FindWithTag ("Player").GetComponent<PlayeurControlleur>().NouvelleLigne(other.transform.position);//rajoute un point de depart de traits
			Destroy (other.gameObject);
			if(first){
				Debug.Log("AJOUT ARRIVER");
				Instantiate(Arriver, other.transform.position, other.transform.rotation); 
				first=false;
			}

		}
		if (other.tag == "arriver") {
			GameObject.FindWithTag ("GameController").GetComponent<GameControlerScript>().FinJeu();//appel de fin jeu
		}

		if (other.tag == "Obstacle") {
			Debug.Log ("toucher");
			Destroy (other.gameObject);
			Instantiate(Explosion, other.transform.position, other.transform.rotation); 
			GameObject.FindWithTag ("GameController").GetComponent<GameControlerScript>().SuppEtoile(); //on supprime une étoile

		}

	}

}
