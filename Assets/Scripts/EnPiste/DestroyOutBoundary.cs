using UnityEngine;
using System.Collections;

public class DestroyOutBoundary : MonoBehaviour {

	//appeler lors de la sortie des element du boundary
	//detruit ttout les object
	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
	}


}
