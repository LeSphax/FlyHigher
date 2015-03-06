using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoaderButton : LoaderButton {

	public Image starImage;
	public Text starText;

	public Sprite starEmpty;
	public Sprite starOnThird;
	public Sprite starTwoThird;
	public Sprite starFull;

	// Use this for initialization
	public override void Init () {
		base.Init ();
	}

	protected override void LockButton () {
		base.LockButton ();
		starText.text = "";
		DisableImage (starImage);
	}

	protected override void UnlockButton ()
	{
		base.UnlockButton ();
		SetStarText ();
		SetStarImage ();
		ResizePanel (120, 75);
	}

	private void SetStarText(){
		starText.text = starsNb.ToString() + "/" + starsMax.ToString();
	}

	private void SetStarImage(){
		float percent = (float)starsNb / (float)starsMax;
		if (percent == 1f) {
			starImage.sprite = starFull;
		} else if (percent >= 0.66f) {
			starImage.sprite = starTwoThird;
		} else if (percent >= 0.33f) {
			starImage.sprite = starOnThird;
		} else {
			starImage.sprite = starEmpty;
		}
	}
}
