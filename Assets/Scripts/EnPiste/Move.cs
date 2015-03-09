using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float movementSpeed;
	 //utiliser pour le déplacement des avions enemies (je croit)
	void Update()
	{
		Vector3 translation=Quaternion.identity* Vector3.right * 1f;
		transform.position += Time.deltaTime * movementSpeed * translation;
	}


}


