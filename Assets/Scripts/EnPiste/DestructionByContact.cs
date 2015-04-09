using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestructionByContact : MonoBehaviour {
	public int vie{ get; set;}
	private GameControler jeu;
	public GameObject Explosion;
	public Text lifeText;

	void Start(){
		vie = 5;
		lifeText.text = ("" + vie);
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
			audio.Play();
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
		lifeText.text = ("" + vie);
	}
}
