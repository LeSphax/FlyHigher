using UnityEngine;
using System.Collections;

public class EndOfGame : MonoBehaviour
{

		public GameObject EndGamePopUp;

		void GameEnded (int numberStars)
		{
				EndGamePopUp.SetActive (true);
				GetComponentInChildren<ScoreStarScript> ().SetStars (numberStars);
                Time.timeScale = 0;
		}
}
