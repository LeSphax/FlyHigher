using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinnigOrLoosing : AbstractWinningOrLoosing {
	
	public Image star1;
	public Image star2;
	public Image star3;

	public Sprite starEmpty;
	public Sprite starFull;

	private int starNb;

	public void SetStarNb(int starNb){
		this.starNb = starNb;
	}

	protected override void InitPart (){
		duration = 4f;
	}

	protected override void SetWinOrLooseText (bool win)
	{
		if (win) {
			winOrLooseText.text = LanguageText.Instance.GetUIText("PopUp.Star.Win");	
		} else {
			winOrLooseText.text = LanguageText.Instance.GetUIText("PopUp.Star.Lose");
		}
	}

	protected override void DisplayTreatment ()
	{
		if (time - beginTime > (((3 * duration) / 4f) + 0.9f)) {
			SetStar3();
		} 
		if (time - beginTime > ((duration / 2f) + 0.9f)) {
			SetStar2();
		}
		if (time - beginTime > ((duration / 4f) + 0.9f)) {
			SetStar1();
		}
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
