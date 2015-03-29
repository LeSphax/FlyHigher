using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlerScript : MonoBehaviour {
	private int etoile;
	public int nbeObjectifsTotal;
	private int nbeObjectifs;
	public Text Tobjectifs;
	// Use this for initialization
	void Start () {
		etoile = 3;
		nbeObjectifs = nbeObjectifsTotal;
		Tobjectifs.text = nbeObjectifs.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//fonction qui doit etre appeler à la fin du jeu
	public void FinJeu(){
		Debug.Log ("FIN JEU: " + nbeObjectifs );
		if (nbeObjectifs == 0) {
			if(etoile<0){
				etoile=0;
			}
			Debug.Log ("appel de gameUI");
			GameObject.FindWithTag ("GamesUI").SendMessage ("GameEnded", etoile);
		}
	}

	//compte le nombre d'etoile ramasser
	public void ObjectifsRamasser(){
		nbeObjectifs--;
		MajObjectifs ();
		/*if (nbeObjectifs <= 0) { //si on à ramasser tout les objectifs on appel la fin du jeu
			FinJeu();
		}
		*/
	}

	private void MajObjectifs(){
		Tobjectifs.text = nbeObjectifs.ToString ();
	}

	public void SuppEtoile(){
		etoile--;
		if(etoile==2){
			Destroy (GameObject.FindWithTag("Star3"));
		}else if(etoile==1){
			Destroy (GameObject.FindWithTag("Star2"));
		}
		else{
			Destroy (GameObject.FindWithTag("Star1"));
		}
	}
}
