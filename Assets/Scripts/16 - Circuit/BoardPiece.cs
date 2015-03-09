using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardPiece : Element {

	public Sprite pieceInGameSprite;
	public Sprite pieceOutGameSprite;

	[HideInInspector] public bool isInGame;

	public void Init (GameObject board, Coordinate c){
		RectTransform frt = board.GetComponent<BoardManager> ().gameController.GetComponent<RectTransform> ();
		RectTransform rt = GetComponent<RectTransform> ();
		base.Init(board, c);
		rt.SetParent(frt);
	}
	
	public void Init (GameObject board, int x, int y){
		Init (board, new Coordinate (x, y));
	}

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
