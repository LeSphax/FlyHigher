using UnityEngine;
using System.Collections;

public abstract class Enemy : MovingObject {

	public abstract bool MoveEnemy (out RaycastHit2D hit);

}
