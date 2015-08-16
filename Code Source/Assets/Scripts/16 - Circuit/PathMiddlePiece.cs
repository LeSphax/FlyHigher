using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PathMiddlePiece : PathPiece {

	[HideInInspector] public Sprite halfPathPieceDownSprite;
	[HideInInspector] public Sprite halfPathPieceRightSprite;
	[HideInInspector] public Sprite halfPathPieceUpSprite;
	[HideInInspector] public Sprite halfPathPieceLeftSprite;
	[HideInInspector] public Sprite pathPieceDownUpSprite;
	[HideInInspector] public Sprite pathPieceRightLeftSprite;
	[HideInInspector] public Sprite anglePieceDownSprite;
	[HideInInspector] public Sprite anglePieceUpSprite;
	[HideInInspector] public Sprite anglePieceRightSprite;
	[HideInInspector] public Sprite anglePieceLeftSprite;

	[HideInInspector] public Direction comming;
	[HideInInspector] public Direction going;

	public void Init(GameObject board, int xBis, int yBis, Direction c, Direction g){
		comming = c;
		going = g;
		base.Init (board, xBis, yBis);
	}

	protected override void SetUp (){}

	public override void Draw (){
		Image skin = GetComponent<Image> ();
		if (((comming == Direction.DOWN) && (going == Direction.RIGHT))
			|| ((comming == Direction.RIGHT) && (going == Direction.DOWN))) {
			skin.sprite = anglePieceDownSprite;
		} else if (((comming == Direction.RIGHT) && (going == Direction.UP))
		    || ((comming == Direction.UP) && (going == Direction.RIGHT))){
			skin.sprite = anglePieceRightSprite;
		} else if (((comming == Direction.UP) && (going == Direction.LEFT))
		    || ((comming == Direction.LEFT) && (going == Direction.UP))){
			skin.sprite = anglePieceUpSprite;
		} else if (((comming == Direction.LEFT) && (going == Direction.DOWN))
		    || ((comming == Direction.DOWN) && (going == Direction.LEFT))){
			skin.sprite = anglePieceLeftSprite;
		} else if (((comming == Direction.DOWN) && (going == Direction.UP))
		    || ((comming == Direction.UP) && (going == Direction.DOWN))){
			skin.sprite = pathPieceDownUpSprite;
		} else if (((comming == Direction.LEFT) && (going == Direction.RIGHT))
		    || ((comming == Direction.RIGHT) && (going == Direction.LEFT))){
			skin.sprite = pathPieceRightLeftSprite;
		} else if (((comming == Direction.DOWN) && (going == Direction.NONE))){
			skin.sprite = halfPathPieceDownSprite;
		} else if (((comming == Direction.RIGHT) && (going == Direction.NONE))){
			skin.sprite = halfPathPieceRightSprite;
		} else if (((comming == Direction.UP) && (going == Direction.NONE))){
			skin.sprite = halfPathPieceUpSprite;
		} else if (((comming == Direction.LEFT) && (going == Direction.NONE))){
			skin.sprite = halfPathPieceLeftSprite;
		}
	}

	public void UpdateGoingDirection (Direction g){
		going = g;
		Draw ();
	}
}
