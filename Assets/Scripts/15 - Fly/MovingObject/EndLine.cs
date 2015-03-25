using UnityEngine;
using System.Collections;

public class EndLine : MovingObject {

	protected override bool HitAntagonist (GameObject hitObject)
	{
		return false;
	}

	public void MoveEndLine (){
		RaycastHit2D hit = new RaycastHit2D ();
		Move (1, 0, out hit);
	}

	protected override void MoveAction (int xDir, int yDir)
	{
		transform.position -= new Vector3 (xDir * speed, yDir, 0) * Time.deltaTime;
	}
}
