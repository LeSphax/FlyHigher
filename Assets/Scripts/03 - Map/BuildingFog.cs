using UnityEngine;
using System.Collections;

public class BuildingFog : MonoBehaviour {


    public string previousBuildingName;
    GameData gameData;
    void Awake()
    {
        gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
    }
    void Start()
    {
        if (gameData.listBuildingsFinished.Contains(previousBuildingName))
        {
            Destroy(gameObject);
        }
        else if (gameData.AreGamesCompletedInBuilding(previousBuildingName))
        {
            gameData.listBuildingsFinished.Add(previousBuildingName);
            this.animation.Play();
        }
    }
}
