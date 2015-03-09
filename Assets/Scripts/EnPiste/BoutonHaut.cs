using UnityEngine;
using System.Collections;

public class BoutonHaut : MonoBehaviour {
	public GameObject plane;

	public void messageHaut()
	{
		if (plane != null)
			plane.SendMessage("Up");
	}
	
	public void messageBas()
	{
		if (plane != null)
			plane.SendMessage("StopUp");
	}
}
