using UnityEngine;
using System.Collections;

public class BoutonGauche : MonoBehaviour {
	public GameObject plane;
	// Update is called once per frame
	public void Tourner()
	{
		if (plane != null)
			plane.SendMessage("TurnLeft");
	}
	
	public void Arreter()
	{
		if (plane != null)
			plane.SendMessage("StopTurning");
	}
}
