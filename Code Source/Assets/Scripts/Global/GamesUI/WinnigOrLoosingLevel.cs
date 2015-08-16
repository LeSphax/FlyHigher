using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinnigOrLoosingLevel : AbstractWinningOrLoosing {
		
	public Image starImage;

	public Sprite starFull;
	public Sprite starEmpty;
	public Sprite thumbsUp;

	private bool starWon;

	public void SetStarWon(bool starWon){
		this.starWon = starWon;
	}

	protected override void InitPart (){
		duration = 2.5f;
		if (starWon) {
			starImage.sprite = starEmpty;
		} else {
			starImage.sprite = thumbsUp;
		}
	}

	protected override void SetWinOrLooseText (bool win){
		winOrLooseText.text = LanguageText.Instance.GetUIText("PopUp.Star.WinLevel");	
	}

	protected override void DisplayTreatment (){
		if (starWon) {
			if (time - beginTime > (duration / 2f)+1f) {
				starImage.sprite = starFull;
			} else {
				starImage.sprite = starEmpty;
			}
		}
	}


}
