using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardPiece : Element {

	public Sprite pieceInGameSprite;
	public Sprite pieceOutGameSprite;

	[HideInInspector] public bool isInGame;

	protected override void SetUp (){
		isInGame = true;
	}

	public override void Draw (){
		Image skin = GetComponent<Image> ();
		if (isInGame) {
			skin.sprite = pieceInGameSprite;
		} else {
			skin.sprite = pieceOutGameSprite;
		}
	}

}
