using UnityEngine;
using System.Collections;

public class CameraScrip : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Vector3 newp;

	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float z = 8.0f;
		//newp = new Vector3 (0.0f, player.transform.position.y + offset.y-1.5f,-z);
		newp = new Vector3 (0.0f, player.transform.position.y + offset.y + 0.5f,-z);
		transform.position = newp;
	
	}
}
