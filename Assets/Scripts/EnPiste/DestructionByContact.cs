using UnityEngine;
using System.Collections;

public class DestructionByContact : MonoBehaviour {
	public int vie{ get; set;}
	private GameControler jeu;
	public GameObject Explosion;

	void Start(){
		vie = 3;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			jeu=gameControllerObject.GetComponent<GameControler>();
		}
		if (gameControllerObject == null) {
			Debug.Log("pas trouver");
		}

	}
	

	void OnTriggerEnter(Collider other){;
		if (other.tag == "Boundary") { //empyeche la destruction si on est sur le boundar
			return;
		}
		if (other.tag == "Player") {
			Destroy(other.gameObject);
			Destroy (gameObject);	
		}
		if (other.tag == "arriver") {
			rigidbody.MovePosition(new Vector3 (0.0f,-10.0f, 0.0f)); //zone ou le personnage va respawn
		}
		if (other.tag=="Enemies"){
			ReductionVie();
			Instantiate(Explosion, other.transform.position, other.transform.rotation); //instancie une explosion a la position de l'impacte
			Destroy(other.gameObject); //supprime l'object qu'il a percuté
		}
		if (vie <= 0){;
			jeu.FinJeu(vie); //appel la fin du jeu
		}

	}
	
	void ReductionVie(){
		vie--;
		if(vie==2){
			Destroy (GameObject.FindWithTag("Star3"));
		}else if(vie==1){
			Destroy (GameObject.FindWithTag("Star2"));
		}
		else{
			Destroy (GameObject.FindWithTag("Star1"));
		}
		
	}
}
