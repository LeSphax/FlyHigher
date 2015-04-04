using UnityEngine;
using System.Collections;

public class EndOfGame : MonoBehaviour
{

		//public GameObject EndGamePopUp;
		public GameObject winnigOrLoosing;
		public GameObject buttons;
		public GameObject lifePanel;
		GameData gameData;

        void Awake()
        {
            gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
        }
        
		void GameEnded (int numberStars=0)
		{
			WinnigOrLoosing wol = winnigOrLoosing.GetComponent<WinnigOrLoosing> ();
			lifePanel.SetActive (false);
			buttons.SetActive (false);
			gameData.AddScore(numberStars);
			wol.Init (numberStars > 0);
			wol.SetStarNb (numberStars);
			Time.timeScale = 0;
		}
}
