using UnityEngine;
using System.Collections;

public class GoToEnding : MonoBehaviour {

    GameData gameData;

    void Awake()
    {
        gameData = GameObject.FindWithTag("GameControler").GetComponent<GameData>();
        if (gameData.AreGamesCompletedInBuilding("ControlTower"))
        {
            Application.LoadLevel("Ending");
        }
    }
}
