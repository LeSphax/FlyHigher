using UnityEngine;
using System.Collections;

public class MovingHand : MonoBehaviour {

	private Vector3 ptA;
	private Vector3 ptB;
	private float speed;
	bool dest = false;
	float timer = 1f;
	float currTimer = 0f;


	// Use this for initialization
	void Start () {
		ptA = GameObject.Find ("Dot0").GetComponent<Transform> ().transform.position + new Vector3(0.1f,-0.7f,-1);
		ptB = GameObject.Find ("Dot1").GetComponent<Transform> ().transform.position + new Vector3(0.1f,-0.7f,-1);
		speed = 1f;
		transform.position = ptA;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Main Camera").GetComponent<mainScriptGame10> ().currentPoint == 2)
			GetComponent<Renderer>().enabled = false;
		if (!dest) {
			Vector3 tmp = transform.eulerAngles;
			transform.LookAt(ptB);
			transform.Translate (0,0,speed * Time.deltaTime);
			transform.eulerAngles = tmp;
			if(Vector3.Distance(transform.position, ptB) < speed * Time.deltaTime)
				dest = true;
		}
		else {
			if(currTimer > timer){
				transform.position = ptA;
				dest = false;
				currTimer = 0f;
			}
			else
				currTimer += Time.deltaTime;
		}
	}
}
