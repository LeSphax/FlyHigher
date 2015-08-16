using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditAction : MonoBehaviour
{

	public void OnClickCredit ()
	{
		ShowPopUp ();
		GetComponentInChildren<Scrollbar> ().value = 1;
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
