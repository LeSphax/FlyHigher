using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    AudioSource backgroundMusic;

    void Awake()
    {
        backgroundMusic = gameObject.GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded()
    {
        if (musicShouldBePlayed())
        {
           backgroundMusic.volume=1.0f;
        }
        else
        {
            backgroundMusic.volume=0f;
        }
    }

    bool musicShouldBePlayed()
    {
        string sn = Application.loadedLevelName;
        return sn == "Loading" || sn == "MainMenu" || sn == "Map" || sn == "Hangar" || sn == "Laboratory" || sn == "ControlTower";
    }
}
