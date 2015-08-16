using UnityEngine;
using System.Collections;

public class backgroundScript: MonoBehaviour {
	private Vector3 vectDepart;
	private Vector3 vectTranslation;
	public float velocity;
	public float size;
	// Use this for initialization
	void Start () {
		vectTranslation = new Vector3 (velocity, 0, 0);
		vectDepart = new Vector3 (-size, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (vectTranslation);
		if(transform.position.z < -(size))
			transform.Translate(vectDepart*2);

	}
}
