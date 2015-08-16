using UnityEngine;
using System.Collections;

public class HotAirBaloon : Enemy {
	
	public override bool MoveEnemy (out RaycastHit2D hit){
		return Move (1, 0, out hit);
	}

	protected override void MoveAction(int xDir, int yDir){
		transform.position -= new Vector3((xDir * speed),
		                                  0,
		                                  0) * Time.deltaTime;
		transform.localPosition = new Vector3 (transform.localPosition.x,
		                                       Mathf.PingPong (Time.time * 3, GameManager.instance.boundaries.yDistance ()+4) - ((GameManager.instance.boundaries.yDistance ()+ 4) / 2f),
		                                       transform.localPosition.z);
	}
}