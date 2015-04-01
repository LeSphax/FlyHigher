using UnityEngine;
using System.Collections;

public class BuildingFog : MonoBehaviour {


    public string buildingName;
    GameData gameData;
    void Awake()
    {
        gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
    }
    void Start()
    {
        if (gameData.listBuildingsFinished.Contains(buildingName))
        {
            Destroy(gameObject);
        }
        else if (gameData.AreGamesCompletedInBuilding(buildingName))
        {
            gameData.listBuildingsFinished.Add(buildingName);
            this.animation.Play();
        }
    }
}
