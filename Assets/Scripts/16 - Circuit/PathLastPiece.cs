using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PathLastPiece : PathPiece {

	public Sprite lastPathPieceSprite;
	public Direction comming;

	public void Init(GameObject board, int xBis, int yBis, Direction g) {
		comming = g;
		base.Init (board, xBis, yBis);
	}
	
	protected override void SetUp (){
		RectTransform rt = GetComponent <RectTransform> ();
		Quaternion rotation = rt.localRotation;
		
		if (comming == Direction.DOWN) {
			rotation.z = 0;
			rt.localRotation = rotation;
		} else if (comming == Direction.UP) {
			rotation.z = 180;
			rt.localRotation = rotation;
		} else if (comming == Direction.RIGHT) {
			rotation.z = 90;
			rt.localRotation = rotation;
		} else if (comming == Direction.LEFT) {
			rotation.z = 270;
			rt.localRotation = rotation;
		}
	}
	
	public override void Draw (){
		Image skin = GetComponent<Image> ();
		
		skin.sprite = lastPathPieceSprite;
	}

}
