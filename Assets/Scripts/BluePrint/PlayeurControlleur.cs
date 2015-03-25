using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayeurControlleur : MonoBehaviour {

	public Camera cam;
	public Ray rayMouse;
	public GameObject player;
//	public List<LineRenderer> lignes = new List<LineRenderer>();
	private int nbeLigne=0;
	public LineRenderer ligne;
	private List<Vector3> points = new List<Vector3> ();
	private bool premierToucher=true;
	private int vertex=1;
	private bool touche=false;

	void Start(){
		//points.Add (Vector3.zero);
		ligne.SetVertexCount(vertex);
	}

	// Use this for initialization
	void Update(){

		if(Input.GetMouseButtonUp(0)){//que faire lorsqu'il leve le doigt
			Debug.Log("lever de bouton");
			touche=false;
		//	LigneMoins();
		//	MajTrait(new Vector3(0.0f,0.0f,0.0f));
		}

		if(Input.GetMouseButton(0)){
			RaycastHit  hit ;
			Ray  ray= cam.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){
				Vector3 pos=new Vector3(hit.point.x, hit.point.y, 0.0f);
				player.transform.position =pos; //deplace le curseur sur le pion courant
				touche=true;
				MajTrait(pos);
			}
		}
	}
	


	//mise a jours des traites
	public void MajTrait(Vector3 pos){
		int i = 0;

		for (i=0; i<nbeLigne; i++) {
			ligne.SetPosition(i,points[i]);	
		}

		if (touche){
			ligne.SetPosition (i, pos);
		}

	}
	
	
	
	//cree une nouvelle ligne qui part de position
	public void NouvelleLigne(Vector3 position){
		nbeLigne++;
		vertex++;
		ligne.SetVertexCount(vertex);
		points.Add (position);
		//Debug.Log("nbligne= " + nbeLigne + "point=" + points.Count + "vertex=" + vertex);
	}

	public void LigneMoins(){
		vertex--;
		ligne.SetVertexCount(vertex);
	//	points.Remove (nbeLigne + 1);
		points.RemoveAt(nbeLigne);
		nbeLigne--;
	}

}
