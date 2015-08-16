using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PopUpHandler : MonoBehaviour
{

	Object prefab;
	GameObject popUp;
	PopUp popUpScript;
	protected System.Collections.Generic.Queue<string> texts;
	protected GameData gameData;
	

	void Awake ()
	{
		gameData = GameObject.FindWithTag ("GameControl").GetComponent<GameData> ();
		prefab = Resources.Load ("StoryPopUp", typeof(GameObject));
	}

	protected virtual void Start ()
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

	protected void CreatePopUp (string text)
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

	public virtual void Next ()
	{
		if (texts.Count > 0) {
			SetText (texts.Dequeue ());
		} else {
			DestroyPopUp ();
		}
	}

	public virtual void Exit ()
	{
	}


	protected void SetPopUpAlreadySeen (string id)
	{
		gameData.listPopUpSeen.Add (id);
	}
	
	
	protected bool AlreadySeen (string id)
	{
		if (gameData.listPopUpSeen.Contains (id)) {
			return true;
		}
		return false;
	}

}
