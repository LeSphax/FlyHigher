using UnityEngine;
using System.Collections;

public class BuildingFog : MonoBehaviour {


    public string previousBuildingName;
    GameData gameData;
    AudioClip windSound;
    void Awake()
    {
        gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
        windSound=Resources.Load("Wind",typeof(AudioClip)) as AudioClip;
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
            this.GetComponent<Animation>().Play();
            AudioSource.PlayClipAtPoint(windSound, transform.position);
        }
    }
}
