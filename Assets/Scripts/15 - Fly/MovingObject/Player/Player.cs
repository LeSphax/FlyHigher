using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	private Animator animator;

	public void Start () {
		animator = GetComponent<Animator> ();
	}


	public void Hit (){
		if (CheckIfGameOver()) {
			animator.SetTrigger ("playerDie");
			Invoke("loadPlayerHit", 0.5f);
		} else {
			animator.SetTrigger ("playerHit");
			loadPlayerHit();
		}
	}

	private void loadPlayerHit(){
		GameManager.instance.PlayerHit ();
	}
	
	private bool CheckIfGameOver (){
		return GameManager.instance.playerHitPoints -1 <= 0; 
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

	protected override bool HitAntagonist (GameObject hitObject)
	{
		return true;
	}
}
