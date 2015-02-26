using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

	public float speed;
	public LayerMask blockingLayer;

	//private Rigidbody2D rb2D;
	private BoxCollider2D bc2D;

	protected virtual bool Move(int xDir, int yDir, out RaycastHit2D hit){
		bc2D = GetComponent<BoxCollider2D> ();
		//rb2D = GetComponent<Rigidbody2D> ();
		Vector2 start = transform.position;
		
		Vector2 end = start + new Vector2 (xDir, yDir);
		
		bc2D.enabled = false;
		
		hit = Physics2D.Linecast (start, end, blockingLayer);
		
		bc2D.enabled = true;
		
		if (hit.transform == null) {
			MoveAction(xDir, yDir);
			return true;
		}
		
		return false;
	}

	protected abstract void MoveAction (int xDir, int yDir);
}
