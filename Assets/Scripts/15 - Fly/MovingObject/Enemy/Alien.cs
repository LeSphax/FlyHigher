using UnityEngine;
using System.Collections;

public class Alien : Enemy {

	[HideInInspector] public int amplitude = 5;

	public override bool MoveEnemy (out RaycastHit2D hit){
		return Move (1, 0, out hit);
	}
	
	protected override void MoveAction(int xDir, int yDir){
		transform.position -= new Vector3(xDir * speed, 
		                                  Mathf.PingPong(Time.time * speed, amplitude)-(amplitude/2),
		                                  0)*Time.deltaTime;
	}
}
