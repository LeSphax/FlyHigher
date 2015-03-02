using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	protected int speed;
	protected float x;
	protected float y;

	// Use this for initialization
	public virtual void Create () {
		speed = Random.Range (5, 10);
		x = (Random.Range (50, 100)) * (1f / 100);
		y = (Random.Range (50, 100)) * (1f / 100);
		transform.localScale = new Vector3 (x, y, 1);
	}
	
	// Update is called once per frame
	public virtual void Move () {
		transform.position -= new Vector3(speed, 0, 0)*Time.deltaTime;
	}

}
