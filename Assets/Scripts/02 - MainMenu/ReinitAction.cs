using UnityEngine;
using System.Collections;

public class ReinitAction : MonoBehaviour
{

	public void OnClickReinit ()
	{
		ShowPopUp ();
	}
	
	public void OnClickClose ()
	{
		HidePopUp ();
	}
	
	private void ShowPopUp ()
	{
		gameObject.SetActive (true);
	}
	
	private void HidePopUp ()
	{
		gameObject.SetActive (false);
	}
}
