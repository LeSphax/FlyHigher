using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PathLastPiece : PathPiece {

	[HideInInspector] public Sprite lastPathPieceSpriteDown;
	[HideInInspector] public Sprite lastPathPieceSpriteUp;
	[HideInInspector] public Sprite lastPathPieceSpriteRight;
	[HideInInspector] public Sprite lastPathPieceSpriteLeft;

	public Direction comming;

	public void Init(GameObject board, int xBis, int yBis, Direction g) {
		comming = g;
		base.Init (board, xBis, yBis);
	}
	
	protected override void SetUp (){}
	
	public override void Draw (){
		Image skin = GetComponent<Image> ();
		if (comming == Direction.DOWN) {
			skin.sprite = lastPathPieceSpriteDown;	
		} else if (comming == Direction.UP) {
			skin.sprite = lastPathPieceSpriteUp;
		} else if (comming == Direction.RIGHT) {
			skin.sprite = lastPathPieceSpriteRight;
		} else if (comming == Direction.LEFT) {
			skin.sprite = lastPathPieceSpriteLeft;
		}
	}

}
