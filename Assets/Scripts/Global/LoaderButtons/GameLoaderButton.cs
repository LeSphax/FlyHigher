using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLoaderButton : LoaderButton {

	public Image star1;
	public Image star2;
	public Image star3;

	public Sprite starEmpty;
	public Sprite starFull;

	protected override void InitPart (){
		this.starsNb = gameData.GetSceneData (sceneName).numberStars;
	}

	protected override void LocksPart ()
	{
		star1.gameObject.SetActive (false);
		star2.gameObject.SetActive (false);
		star3.gameObject.SetActive (false);
	}

	protected override void UnlocksPart ()
	{
		star1.gameObject.SetActive (true);
		star2.gameObject.SetActive (true);
		star3.gameObject.SetActive (true);
		SetStarImages ();
	}

	private void SetStarImages(){
		switch (starsNb) {
		case 3:
			star1.sprite = starFull;
			star2.sprite = starFull;
			star3.sprite = starFull;
			break;
		case 2:
			star1.sprite = starFull;
			star2.sprite = starFull;
			star3.sprite = starEmpty;
			break;
		case 1:
			star1.sprite = starFull;
			star2.sprite = starEmpty;
			star3.sprite = starEmpty;
			break;
		case 0:
		default:
			star1.sprite = starEmpty;
			star2.sprite = starEmpty;
			star3.sprite = starEmpty;
			break;
		}
	}
}
