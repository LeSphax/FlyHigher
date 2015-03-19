using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PopUpHandler : MonoBehaviour
{

	Object prefab;
	GameObject popUp;
	PopUp popUpScript;
	System.Collections.Generic.Queue<string> texts;
	private static List<string> listPopUpSeen = new List<string> ();
	

	void Awake ()
	{
		prefab = Resources.Load ("StoryPopUp", typeof(GameObject));
	}

	void Start ()
	{
		texts = GetTexts ();
		if (texts.Count > 0) {
			CreatePopUp (texts.Dequeue ());
		}
	}

	protected abstract System.Collections.Generic.Queue<string> GetTexts ();

	protected System.Collections.Generic.Queue<string> GetTexts (string id)
	{
		return LanguageText.Instance.GetHistoryTexts (id);
	}
	void CreatePopUp (string text)
	{
		popUp = Instantiate (prefab) as GameObject;
		popUpScript = popUp.GetComponent<PopUp> ();
		SetText (text);
	}

	public void SetText (string text)
	{
		popUpScript.SetText (text, this);
	}

	public void DestroyPopUp ()
	{
		popUpScript.Exit ();
	}

	public void Next ()
	{
		if (texts.Count > 0) {
			SetText (texts.Dequeue ());
		} else {
			DestroyPopUp ();
		}
	}


	public static void SetPopUpAlreadySeen (string id)
	{
		listPopUpSeen.Add (id);
	}
	
	
	public static bool AlreadySeen (string id)
	{
		if (listPopUpSeen.Contains (id)) {
			return true;
		}
		return false;
	}

}
