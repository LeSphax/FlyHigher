using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinnigOrLoosing : MonoBehaviour {

	public Text winOrLooseText;
	public Image star1;
	public Image star2;
	public Image star3;
	public GameObject endPopUp;
	public GameObject winningOrLoosing;
	public Sprite starEmpty;
	public Sprite starFull;

	private int starNb;
	private float startTime;

	/*public void Start(){
		Init (2);
	}*/

	public void Init(int starNb){
		winningOrLoosing.SetActive(true);
		startTime = 0;
		this.starNb = starNb;
		if (this.starNb > 0) {
			winOrLooseText.text = LanguageText.Instance.GetUIText("PopUp.Star.Win");
		} else {
			winOrLooseText.text = LanguageText.Instance.GetUIText("PopUp.Star.Lose");
		}
		RectTransform rt = GetComponent<RectTransform> ();
		Vector3 v3 = rt.anchoredPosition;
		v3.x = 600;
		rt.anchoredPosition = v3;
	}

	public void Update(){
		startTime += 0.01f;
		Debug.Log (startTime);
		if (GetComponent <RectTransform>().anchoredPosition.x > 0) Move();
		else if (startTime < 3f){
			if (startTime > 2.5f) {
				SetStar3();
			} else if (startTime > 1.5f) {
				SetStar2();
			} else if (startTime > 0.5f) {
				SetStar1();
			}
		}else if (GetComponent <RectTransform>().position.x > - 160) {
			Move();
		} else {
			RectTransform rt = GetComponent<RectTransform> ();
			Vector3 v3 = rt.anchoredPosition;
			v3.x = 600;
			rt.anchoredPosition = v3;
			endPopUp.SetActive(true);
			GameObject.FindGameObjectWithTag("WinningOrLoosing").SetActive(false);
		}

	}

	private void Move(){
		RectTransform rt = GetComponent<RectTransform> ();
		Vector3 v3 = rt.position;
		v3.x -= 3f;
		rt.position = v3;
	}

	private void SetStar1(){
		if (starNb < 1) star1.sprite = starEmpty;
		else star1.sprite = starFull;
	}

	private void SetStar2(){
		if (starNb < 2) star2.sprite = starEmpty;
		else star2.sprite = starFull;
	}

	private void SetStar3(){
		if (starNb < 3) star3.sprite = starEmpty;
		else star3.sprite = starFull;
	}
}
