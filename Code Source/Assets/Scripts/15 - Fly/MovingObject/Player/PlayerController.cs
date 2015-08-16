using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Player player;

	// Use this for initialization
	public void Start () {
		player = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hitt = new RaycastHit2D();
		bool bt;
		if (Input.touchCount > 0)
			bt = player.MovePlayer (true, out hitt);
		else
			bt = player.MovePlayer (false, out hitt);
			
		if(hitt.transform != null){
			//Get a component reference to the component of type T attached to the object that was hit
			Enemy hitComponent = hitt.transform.GetComponent <Enemy> ();
				
			//If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
			if(!bt && hitComponent != null){

				player.Hit(hitComponent.GetComponent<Enemy>());
				GameManager.instance.enemiesManager.DestroyEnemy (hitComponent);
			}
		}
	}
}
