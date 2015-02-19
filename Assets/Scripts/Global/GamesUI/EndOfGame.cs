using UnityEngine;
using System.Collections;

public class EndOfGame : MonoBehaviour {

   public GameObject EndGamePopUp;

    void GameEnded()
    {
        EndGamePopUp.SetActive(true);
    }
}
