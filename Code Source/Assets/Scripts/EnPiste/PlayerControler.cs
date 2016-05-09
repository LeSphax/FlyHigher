using UnityEngine;
using System.Collections;

[System.Serializable]
public class Contour{
	public float xMa,xMi,yMa,yMi;
}
/*Script pour controler le déplacement de l'avion*/

public class PlayerControler : MonoBehaviour {
	public float speed;
	public Contour bordure;
	public int rotatonSpeed;
	//public int rotationDeceleration;
	public int movementSpeed;
	public int moveUp;
	int rotationDirection;


	void Update()
	{
		//deplacement de l'avion
		Vector3 movement = new Vector3 (rotationDirection,moveUp,0.0f);
		GetComponent<Rigidbody>().velocity = movement * speed;

		//controle les sortie d'ecran
		float x = GetComponent<Rigidbody>().position.x;
		float y = GetComponent<Rigidbody>().position.y;
		if (GetComponent<Rigidbody>().position.x < bordure.xMi) {
			x = bordure.xMi;
			GetComponent<Rigidbody>().position=new Vector3(x,y,0.0f);
		}
		if (GetComponent<Rigidbody>().position.x > bordure.xMa) {
			x=bordure.xMa;
			GetComponent<Rigidbody>().position=new Vector3(x,y,0.0f);
		}
		if (GetComponent<Rigidbody>().position.y < bordure.yMi) {
			y=bordure.yMi;
			GetComponent<Rigidbody>().position=new Vector3(x,y,0.0f);
		}
		if (GetComponent<Rigidbody>().position.y > bordure.yMa) {
			y=bordure.yMa;
			GetComponent<Rigidbody>().position=new Vector3(x,y,0.0f);
		}
	}


	/*------------------------------------*/
	/* fonctions appeler par les events generer par 
	 * l'interaction avec le tactil */
	/*------------------------------------------*/
	void TurnLeft()
	{
		rotationDirection = -1;
	}
	
	void TurnRight()
	{
		rotationDirection = 1;
	}
	
	void StopTurning()
	{
		rotationDirection = 0;
	}

	void Up(){
		moveUp = 1;	
	}

	public void StopUp(){
		moveUp=0;
	}
	
}