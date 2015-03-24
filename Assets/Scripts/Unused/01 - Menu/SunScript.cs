using UnityEngine;
using System.Collections;

public class SunScript : MonoBehaviour {
	private float counter;
	public byte state;
	private float timer;

	// Use this for initialization
	void Start () {
		counter = 0f;
		timer = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<SpriteRenderer>().color = Color.red;

		transform.RotateAround (new Vector3(0,-10,0), Vector3.left, 3 * Time.deltaTime);
		counter += Time.deltaTime;

		if (counter > timer && state == 0) {
						transform.position = new Vector3 (-8, -25, -7);
						//transform.rotation = new Quaternion(0,45,0,0);
						state = 1;
						counter -= timer;
				}
		if (counter > timer && state == 1){
						transform.position = new Vector3 (-8,5,7);
						state = 0;
						counter -= timer;
				}
	}
}
