using UnityEngine;
using System.Collections;

public abstract class PathPiece : Element {

	public enum Direction {UP, DOWN, RIGHT, LEFT, NONE}

	public static Direction OppositeDirection(Direction d){
		if (d == Direction.UP) return Direction.DOWN;
		else if (d == Direction.DOWN) return Direction.UP;
		else if (d == Direction.RIGHT) return Direction.LEFT;
		else if (d == Direction.LEFT) return Direction.RIGHT;
		else return Direction.NONE;
	}

}
