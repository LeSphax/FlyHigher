using UnityEngine;
using System.Collections;

public class CloudBis : Cloud {

	// Use this for initialization
	public override void Create () {
		speed = Random.Range (3, 7);
		x = (Random.Range (50, 100)) * (1f / 100);
		y = (Random.Range (50, 100)) * (1f / 100);
		transform.localScale = new Vector3 (x, y, 1);
	}
	
	// Update is called once per frame
	public override void Move () {
		transform.position += new Vector3(speed, 0, 0)*Time.deltaTime;
	}
}
