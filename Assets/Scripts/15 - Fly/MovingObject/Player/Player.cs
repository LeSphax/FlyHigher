using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	private Animator animator;

	public void Start () {
		animator = GetComponent<Animator> ();
	}


	public void Hit (){
		GameManager.instance.playerHitPoints --;
		if (CheckIfGameOver()) {
			animator.SetTrigger ("playerDie");
			GameManager.instance.GameOver();

		} else {
			animator.SetTrigger ("playerHit");
		}
	}
	
	private bool CheckIfGameOver (){
		return GameManager.instance.playerHitPoints <= 0; 
	}

	public bool MovePlayer(bool up, out RaycastHit2D hit){
		if (up) return Move (0, 1, out hit);
		else return Move (0, -1, out hit);
	}

	protected override void MoveAction (int xDir, int yDir){
		transform.position = new Vector3 (transform.position.x,
		                                  Mathf.Clamp (transform.position.y + (yDir * speed * Time.deltaTime), 
		                       				GameManager.instance.boundaries.yMin + 2f,
		                            		GameManager.instance.boundaries.yMax - 2.5f),
		                                  transform.position.z);
	}
}
