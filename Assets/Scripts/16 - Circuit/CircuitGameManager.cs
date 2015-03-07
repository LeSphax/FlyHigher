using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircuitGameManager : MonoBehaviour {

	public GameObject board;
	public GameObject levelLoader;

	// Use this for initialization
	void Start () {

	}

	public void Init (int lvl) {
		Level l = board.GetComponent<Level> ();
		l.LevelLoader (lvl);
		levelLoader.SetActive (false);
		
	}
}
