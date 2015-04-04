using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class AbstractWinningOrLoosing : MonoBehaviour {

	public Text winOrLooseText;
	public GameObject endPopUp;
	public GameObject winningOrLoosing;

	protected float time;
	private const float OUT_OF_SCREEN_POSITION = 700f;
	protected float beginTime;
	protected float duration;

	public void Init(bool win){

		beginTime = Time.unscaledTime;
		time = beginTime;
		SetWinOrLooseText (win);
		SetPositionToStart ();
		InitPart ();
		winningOrLoosing.SetActive (true);
	}

	protected abstract void InitPart ();

	private void SetPositionToStart(){
		RectTransform rt = GetComponent<RectTransform> ();
		Vector3 v3 = rt.anchoredPosition;
		v3.x = OUT_OF_SCREEN_POSITION;
		rt.anchoredPosition = v3;
	}

	protected abstract void SetWinOrLooseText(bool win);

	public void Update(){
		RectTransform rt = GetComponent<RectTransform> ();
		if (rt.anchoredPosition.x > 0) MoveWOL();
		time += Time.unscaledDeltaTime;
		if (time < GetEndTime()){
			DisplayTreatment();
		}else if (rt.anchoredPosition.x > (-OUT_OF_SCREEN_POSITION)) {
			MoveWOL();
		} else {
			SetPositionToStart();
			endPopUp.SetActive(true);
			winningOrLoosing.SetActive(false);
		}
	}

	protected abstract void DisplayTreatment();
	
	private void MoveWOL(){
		RectTransform rt = GetComponent<RectTransform> ();
		Vector3 v3 = rt.position;
		v3.x -= Time.unscaledDeltaTime*OUT_OF_SCREEN_POSITION;
		rt.position = v3;
	}

	public void OnClickEventHandler(){
		time = beginTime + duration + Time.unscaledDeltaTime;
		DisplayTreatment ();
	}

	protected float GetEndTime(){
		return beginTime + duration;
	}
}
