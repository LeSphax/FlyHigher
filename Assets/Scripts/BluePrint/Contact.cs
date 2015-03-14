using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {

	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Point") {
			Destroy (other.gameObject);
		}
	}

}
