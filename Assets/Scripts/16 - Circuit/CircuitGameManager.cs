using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircuitGameManager : MonoBehaviour {

	public GameObject board;

	// Use this for initialization
	void Start () {
		
		Level l = board.GetComponent<Level> ();
		l.LevelLoader (1);
	}
}
