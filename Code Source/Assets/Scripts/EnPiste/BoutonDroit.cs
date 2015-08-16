using UnityEngine;
using System.Collections;

public class BoutonDroit : MonoBehaviour {
	public GameObject plane;
	public void Tourner()
	{
		if (plane != null)
			plane.SendMessage("TurnRight");
	}
	
	public void Arreter()
	{
		if (plane != null)
			plane.SendMessage("StopTurning");
	}
}
