using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {
	private float counter;
	public byte state;
	private float timerOn;
	private float timerOff;
	
	// Use this for initialization
	void Start () {
		GetComponent<ParticleEmitter>().emit = true;
		state = 1;
		timerOn = 16f;
		timerOff = 24f;
		counter = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > timerOff && state == 0) {
			//Debug.Log("particle on");
			GetComponent<ParticleEmitter>().emit = true;
			state = 1;
			counter -= timerOff;
		}
		if (counter > timerOn && state == 1){
			GetComponent<ParticleEmitter>().emit = false;
			state = 0;
			counter -= timerOn;
		}
		
	}
}