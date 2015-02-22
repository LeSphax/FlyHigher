using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	private int speed;
	private float x;
	private float y;

	// Use this for initialization
	public void Create () {
		speed = Random.Range (5, 10);
		x = (Random.Range (50, 100)) * (1f / 100);
		y = (Random.Range (50, 100)) * (1f / 100);
		transform.localScale = new Vector3 (x, y, 1);
		Debug.Log ("X : " + x + ", Y : " + y + ", SPEED: " + speed);
	}
	
	// Update is called once per frame
	public void Move () {
		transform.position -= new Vector3(speed, 0, 0)*Time.deltaTime;
	}

}
