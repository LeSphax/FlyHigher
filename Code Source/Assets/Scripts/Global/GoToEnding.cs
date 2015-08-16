using UnityEngine;
using System.Collections;

public class GoToEnding : MonoBehaviour {

    GameData gameData;
    public string idEnding;

    void Awake()
    {
        gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
        if (gameData.AreGamesCompletedInBuilding(Application.loadedLevelName) && !gameData.listPopUpSeen.Contains(idEnding))
        {
            gameData.listPopUpSeen.Add(idEnding);
            Application.LoadLevel("Ending");
        }
    }
}
