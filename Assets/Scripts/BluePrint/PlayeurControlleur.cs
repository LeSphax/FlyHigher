using UnityEngine;
using System.Collections;

public class PlayeurControlleur : MonoBehaviour {

	public Camera cam;
	public Ray rayMouse;

	public GameObject player;

	// Use this for initialization
	void Update(){
		if(Input.GetMouseButton(0)){
			RaycastHit  hit ;
			Ray  ray= cam.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){ 
				Vector3 pos=new Vector3(hit.point.x, hit.point.y, 0.0f);
				player.transform.position =pos; //deplace le curseur sur le pion courant
			}
		}
	}
}
