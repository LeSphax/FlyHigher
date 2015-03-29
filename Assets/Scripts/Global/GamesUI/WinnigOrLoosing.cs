using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinnigOrLoosing : MonoBehaviour {

	public Text winOrLooseText;
	public Image star1;
	public Image star2;
	public Image star3;
	public GameObject endPopUp;

	public Sprite starEmpty;
	public Sprite starFull;

	private int starNb;
	private float startTime;

	public void Start(){
		Init (2);
	}

	public void Init(int starNb){
		GameObject.FindGameObjectWithTag("WinningOrLoosing").SetActive(true);
		startTime = Time.time;
		this.starNb = starNb;
		if (this.starNb > 0) {
			winOrLooseText.text = LanguageText.Instance.GetUIText("PopUp.Star.Lose");
		} else {
			winOrLooseText.text = LanguageText.Instance.GetUIText("PopUp.Star.Win");
		}
		RectTransform rt = GetComponent<RectTransform> ();
		Vector3 v3 = rt.anchoredPosition;
		v3.x = 600;
		rt.anchoredPosition = v3;
	}

	public void Update(){

		if (GetComponent <RectTransform>().anchoredPosition.x > 0) Move();
		else if (Time.time < startTime + 3f){
			if (Time.time > startTime + 1.9f) {
				SetStar3();
			} else if (Time.time > startTime + 1.5f) {
				SetStar2();
			} else if (Time.time > startTime + 1.1f) {
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
		v3.x -= 500f * Time.deltaTime;
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
