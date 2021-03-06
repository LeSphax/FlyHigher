﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SceneLoaderButton : LoaderButton {

	public GameObject titlePanel;
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
		GetComponent<Button> ().interactable = false;
		RectTransform rt = lockImage.GetComponent<RectTransform> ();
		Vector2 size = rt.sizeDelta;
		size.x = 80;
		size.y = 80;
		rt.sizeDelta = size;
		size = rt.anchoredPosition;
		size.x = 0;
		size.y = 0;
		rt.anchoredPosition = size;
		titlePanel.SetActive (false);
		starImage.gameObject.SetActive (false);
		starText.gameObject.SetActive (false);
	}

	protected override void UnlocksPart ()
	{
		titlePanel.SetActive (true);
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
