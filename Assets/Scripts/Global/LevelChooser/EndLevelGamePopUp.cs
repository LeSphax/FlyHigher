using UnityEngine;
using System.Collections;

public class EndLevelGamePopUp : MonoBehaviour {

	public GameObject endGamePopUp;
	public GameObject levelChooser;
	public GameObject buttons;

	GameData gameData;
	
	void Awake()
	{
		gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
	}
	
	public void GameEnded ()
	{
		endGamePopUp.SetActive (true);
		buttons.SetActive (false);
		levelChooser.GetComponent<LevelChooser>().SaveLevel();
		Time.timeScale = 0;
	}

	public void Restart (){
		LevelChooser lv = levelChooser.GetComponent<LevelChooser> ();
		endGamePopUp.SetActive (false);
		buttons.SetActive (true);
		lv.al.Clear();
		lv.LoadLevel(lv.levelNb);
        Time.timeScale = 1;
	}
}
