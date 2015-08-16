using UnityEngine;
using System.Collections;

public class EndLevelGamePopUp : MonoBehaviour {

	public GameObject endGamePopUp;
	public GameObject levelChooser;
	public GameObject buttons;
	public GameObject winOrLoose;
	
	public void LevelEnded ()
	{
		LevelChooser lv = levelChooser.GetComponent<LevelChooser> ();
		WinnigOrLoosingLevel woll = winOrLoose.GetComponent<WinnigOrLoosingLevel> ();
		woll.SetStarWon (lv.IsLevelStarWinning());
		woll.Init (true);
		buttons.SetActive (false);
		lv.SaveLevel();
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

	public void Next (){
		LevelChooser lv = levelChooser.GetComponent<LevelChooser> ();
		if (lv.isLastLevel()) {
			GameObject.FindWithTag("MainCamera").SendMessage("ReturnPressed");
		} else {
			endGamePopUp.SetActive (false);
			buttons.SetActive (true);
			lv.al.Clear();
			lv.LoadLevel(lv.levelNb + 1);
			Time.timeScale = 1;
		}
	}
}
