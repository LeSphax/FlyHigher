using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircuitGameManager : MonoBehaviour {

	public GameObject board;
	public GameObject levelLoader;

	private int lvlNb;

	public void Init (int lvl) {
		lvlNb = lvl;
		Level l = board.GetComponent<Level> ();
		l.LevelLoader (lvl);
		levelLoader.SetActive (false);
	}

	public void LevelEnded (bool finished) {
		levelLoader.SetActive (true);
		board.GetComponent<BoardManager> ().ResetBoard ();
		//TODO notifier au gameData
	}
}
