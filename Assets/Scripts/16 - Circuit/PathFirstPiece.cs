using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PathFirstPiece : PathPiece {

	[HideInInspector] public Sprite firstPathPieceSpriteDown;
	[HideInInspector] public Sprite firstPathPieceSpriteUp;
	[HideInInspector] public Sprite firstPathPieceSpriteRight;
	[HideInInspector] public Sprite firstPathPieceSpriteLeft;

	public Direction going;

	public void Init(GameObject board, int xBis, int yBis, Direction g) {
		going = g;
		base.Init (board, xBis, yBis);
	}

	protected override void SetUp (){}

	public override void Draw (){
		Image skin = GetComponent<Image> ();
		if (going == Direction.DOWN) {
			skin.sprite = firstPathPieceSpriteDown;	
		} else if (going == Direction.UP) {
			skin.sprite = firstPathPieceSpriteUp;
		} else if (going == Direction.RIGHT) {
			skin.sprite = firstPathPieceSpriteRight;
		} else if (going == Direction.LEFT) {
			skin.sprite = firstPathPieceSpriteLeft;
		}
	}

}
