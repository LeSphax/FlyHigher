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

	void Start(){
		//points.Add (Vector3.zero);
		ligne.SetVertexCount(20);
	}

	// Use this for initialization
	void Update(){

		if(Input.GetMouseButtonUp(0)){
			//GameObject.FindWithTag ("GameController").GetComponent<GameControlerScript>().FinJeu();

		}

		if(Input.GetMouseButton(0)){
			RaycastHit  hit ;
			Ray  ray= cam.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){
				Vector3 pos=new Vector3(hit.point.x, hit.point.y, 0.0f);
				player.transform.position =pos; //deplace le curseur sur le pion courant
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

		/*
		foreach (Vector3 p in points)
		{
			ligne.SetPosition(i, p);	
			i++;
		}
		*/

		ligne.SetPosition(i+1, pos);
			
		
	}
	
	
	
	//cree une nouvelle ligne qui part de position
	public void NouvelleLigne(Vector3 position){
		Debug.Log ("appel de nouvelle ligne");
		points.Add (position);
		nbeLigne++;
	}

}
