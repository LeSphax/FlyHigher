using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLoader : LoaderButton {

	public Image star1;
	public Image star2;
	public Image star3;

	public Sprite starEmpty;
	public Sprite starFull;

	// Use this for initialization
	public override void Init () {
		base.Init ();
	}

	protected override void LockButton () {
		base.LockButton ();
		DisableImage (star1);
		DisableImage (star2);
		DisableImage (star3);
	}

	protected override void UnlockButton() {
		base.UnlockButton ();
		ResizePanel (120, 75);
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
