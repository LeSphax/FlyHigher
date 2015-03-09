using UnityEngine;
using System.Collections;

public class MoveEnemiesAvion : MonoBehaviour {

	public float movementSpeed;
	
	void Update()
	{
		Vector3 translation=Quaternion.identity* Vector3.right * 1f;
		transform.position += Time.deltaTime * movementSpeed * translation;
	}
	

}
