using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

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
		this.starsNb = gameData.GetBuildingCurrentStars (sceneName);
		try{
			this.starsMaxNb = gameData.GetBuildingData (sceneName).nbGames * 3;
		} catch {
            Debug.LogError("Probleme GetBuildingData in SceneLoaderButton");
			this.starsMaxNb = -1;
		}
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
		SetStarText ();
		SetStarImage ();
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
}
