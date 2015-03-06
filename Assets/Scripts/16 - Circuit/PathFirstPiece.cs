using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PathFirstPiece : PathPiece {

	public Sprite firstPathPieceSprite;
	public Direction going;

	public void Init(GameObject board, int xBis, int yBis, Direction g) {
		going = g;
		base.Init (board, xBis, yBis);
	}

	protected override void SetUp (){
		RectTransform rt = GetComponent <RectTransform> ();
		Quaternion rotation = rt.localRotation;

		if (going == Direction.DOWN) {
			rotation.z = 0;
			rt.localRotation = rotation;
		} else if (going == Direction.UP) {
			rotation.z = 180;
			rt.localRotation = rotation;
		} else if (going == Direction.RIGHT) {
			rotation.z = 90;
			rt.localRotation = rotation;
		} else if (going == Direction.LEFT) {
			rotation.z = 270;
			rt.localRotation = rotation;
		}
	}
	
	public override void Draw (){
		Image skin = GetComponent<Image> ();

		skin.sprite = firstPathPieceSprite;
	}

}
