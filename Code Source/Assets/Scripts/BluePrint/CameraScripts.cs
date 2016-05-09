using UnityEngine;
using System.Collections;

public class CameraScripts : MonoBehaviour {

	public Ray rayMouse;
	public RaycastHit hit;
	public GameObject objectif;

	void Update() {
		rayMouse = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast(rayMouse,out hit)) {
			{
				if(hit.transform.name==objectif.name)
				{
				//	Debug.Log("TOUCHER§§§");
				}
			}
		}
	}
}

