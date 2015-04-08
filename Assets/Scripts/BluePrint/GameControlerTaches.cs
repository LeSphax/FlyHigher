using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlerTaches : MonoBehaviour {
	public GameObject taches;
	public int nbeTaches;
	private int nbeTachesSurEcran;
	public Text Tobjectifs;
	public Text TempsRestant;
	private bool gameOver;
	public float Tps;
	private int etoile;
	private float seconde;
	// Use this for initialization


	void Start () {
		seconde = Time.time;
		etoile = 3;
		gameOver = true;
		nbeTachesSurEcran = 0;
		ApparitionTache ();
		MajNbeTaches ();
		StartCoroutine(SpawnTaches());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

			
	/* fonction qui fait apparaitre des taches */
	IEnumerator SpawnTaches(){
		//int nbeEnemies = 0;
		float x;
		float y;
		Vector3 spawnPosition;
		yield return new WaitForSeconds (0);
		while (gameOver) {
			x=Random.Range (-15,15); //-22;22
			y=Random.Range(-10,11); //-10;13
			spawnPosition= new Vector3 (x,y,0);
			Instantiate(taches, spawnPosition,Quaternion.identity); //fait apparaitre un chariot
			nbeTachesSurEcran++;
			MajNbeTaches();
			FinJeuTemps();
			yield return new WaitForSeconds(Tps);
		}
	}


	//enléve des etoiles au fur et a mesure que le temps passe
	public void FinJeuTemps(){
		float difSeconde=Time.time-seconde;
		int difSecInt = (int) (30-difSeconde);
		TempsRestant.text = difSecInt.ToString ();
		//seconde=Time.time;
		if (difSeconde > 10 && difSeconde<11) {
			ReductionVie();
		}else if(difSeconde>20 && difSeconde<21){
			ReductionVie();
		}
		if(difSeconde>30){
			ReductionVie();
			GameObject.FindWithTag ("GamesUI").SendMessage ("GameEnded",etoile);
		}

	}




	//fait apparaitre nbeTaches d'un coups
	private void ApparitionTache(){
		float x;
		float y;
		int i;
		Vector3 spawnPosition;
		for(i=0;i<nbeTaches;i++){
			x=Random.Range (-15,15); //-22;22
			y=Random.Range(-10,11); //-10;13
			spawnPosition = new Vector3 (x,y,0);
			Instantiate(taches, spawnPosition,Quaternion.identity); //fait apparaitre un chariot
			nbeTachesSurEcran++;
		}

	}
	
	//baisse le nombre de taches
	public void SupprimerTaches(){
		nbeTachesSurEcran--;
		MajNbeTaches ();
		FinJeu ();
	}



	//maj du texte donnant le nombre de taches restantes
	private void MajNbeTaches(){
		Tobjectifs.text = nbeTachesSurEcran.ToString ();
	}



	//fonction qui doit etre appeler à la fin du jeu
	public void FinJeu(){
		if (nbeTachesSurEcran == 0) {
			GameObject.FindWithTag ("GamesUI").SendMessage ("GameEnded",etoile);
		}
	}


	void ReductionVie(){
		etoile--;
	}


}
