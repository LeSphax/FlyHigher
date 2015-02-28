using UnityEngine;
using System.Collections;

public class EndOfGame : MonoBehaviour
{

		public GameObject EndGamePopUp;
        GameData gameData;

        void Awake()
        {
            gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
        }
        
		void GameEnded (int numberStars)
		{
				EndGamePopUp.SetActive (true);
                gameData.AddScore(numberStars);
                GetComponentInChildren<ScoreStarScript>().ShowStars();
                Time.timeScale = 0;
		}
}
