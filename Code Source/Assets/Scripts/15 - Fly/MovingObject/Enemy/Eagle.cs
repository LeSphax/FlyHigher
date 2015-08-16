using UnityEngine;
using System.Collections;

public class Eagle : Enemy {

	private bool b;

	public override bool MoveEnemy (out RaycastHit2D hit){
		return Move (1, 0, out hit);
	}

	protected override void MoveAction(int xDir, int yDir){
		transform.position -= new Vector3 (xDir * speed, yDir, 0) * Time.deltaTime;
	}
}
