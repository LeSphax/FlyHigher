using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CircuitGameManager : MonoBehaviour {

	public GameObject board;
	public GameObject levelLoader;
	public Button levelButton;

	private int lvlNb;

	public void Init (int lvl) {
		lvlNb = lvl;
		CircuitLevels l = board.GetComponent<CircuitLevels> ();
		l.LoadLevel (lvl);
		levelLoader.SetActive (false);
		levelButton.gameObject.SetActive (true);
	}

	public void LevelEnded () {
		//TODO sauvegarder le niveau

		GetComponent<buttonLoadScene> ().loadScene ();
	}
}
