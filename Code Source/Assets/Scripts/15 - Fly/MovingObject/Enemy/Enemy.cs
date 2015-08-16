using UnityEngine;
using System.Collections;

public abstract class Enemy : MovingObject {

	public void Create(float speed){
		this.speed = speed;
	}

	public abstract bool MoveEnemy (out RaycastHit2D hit);

	protected override bool HitAntagonist (GameObject hitObject)
	{
		if (hitObject.tag.Equals ("Player")) {
			Player p = hitObject.GetComponent<Player>();
			return !p.IsPlayerInvincible();
		}
		return false;
	}

}
