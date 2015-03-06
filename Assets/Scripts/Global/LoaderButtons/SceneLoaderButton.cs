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

	protected int starsMaxNb;

	protected override void InitPart ()
	{
		this.starsMaxNb = gameData.GetBuildingData (name).nbGames * 3;
	}

	protected override void LocksPart ()
	{
		starImage.gameObject.SetActive (false);
		starText.gameObject.SetActive (false);
	}

	protected override void UnlocksPart ()
	{
		starImage.gameObject.SetActive (true);
		starText.gameObject.SetActive (true);
	}

	private void SetStarText(){
		starText.text = starsNb.ToString() + "/" + starsMaxNb.ToString();
	}
	
	private void SetStarImage(){
		float percent = (float)starsNb / (float)starsMaxNb;
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

	/*protected override void LockButton () {
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

	 */
}
