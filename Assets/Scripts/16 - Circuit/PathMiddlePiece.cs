using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PathMiddlePiece : PathPiece {

	public Sprite halfPathPieceSprite;
	public Sprite pathPieceSprite;
	public Sprite anglePieceSprite;

	[HideInInspector] public Direction comming;
	[HideInInspector] public Direction going;

	public void Init(GameObject board, int xBis, int yBis, Direction c, Direction g){
		comming = c;
		going = g;
		base.Init (board, xBis, yBis);
	}

	protected override void SetUp (){
		RectTransform rt = GetComponent <RectTransform> ();
		Quaternion rotation = rt.localRotation;
		
		if (((comming == Direction.DOWN) && (going == Direction.RIGHT)) 
		    || ((comming == Direction.RIGHT) && (going == Direction.DOWN))
		    || ((comming == Direction.DOWN) && (going == Direction.UP))
		    || ((comming == Direction.UP) && (going == Direction.DOWN))
		    || ((comming == Direction.DOWN) && (going == Direction.NONE))) {
			rotation.z = 0;
			rt.localRotation = rotation;
		} else if (((comming == Direction.RIGHT) && (going == Direction.UP)) 
		    || ((comming == Direction.UP) && (going == Direction.RIGHT))
		    || ((comming == Direction.RIGHT) && (going == Direction.NONE))) {
			rotation.z = 180;
			rt.localRotation = rotation;
		} else if (((comming == Direction.UP) && (going == Direction.LEFT)) 
		    || ((comming == Direction.LEFT) && (going == Direction.UP))
		    || ((comming == Direction.RIGHT) && (going == Direction.LEFT))
		    || ((comming == Direction.LEFT) && (going == Direction.RIGHT))
		    || ((comming == Direction.UP) && (going == Direction.NONE))) {
			rotation.z = 90;
			rt.localRotation = rotation;
		} else if (((comming == Direction.LEFT) && (going == Direction.DOWN)) 
		    || ((comming == Direction.DOWN) && (going == Direction.LEFT))
		    || ((comming == Direction.LEFT) && (going == Direction.NONE))) {
			rotation.z = 270;
			rt.localRotation = rotation;
		}
	}

	public override void Draw (){
		Image skin = GetComponent<Image> ();
		if (going == Direction.NONE) skin.sprite = halfPathPieceSprite;
		else if (comming == OppositeDirection (going)) skin.sprite = pathPieceSprite;
		else skin.sprite = anglePieceSprite;
	}

	public void UpdateGoingDirection (Direction g){
		going = g;
		SetUp ();
		Draw ();
	}
}
