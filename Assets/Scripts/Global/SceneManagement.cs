using UnityEngine;
using System.Collections;

public class SceneManagement : MonoBehaviour
{

    string previousScene { get; set; }
    string currentScene { get; set; }

    void OnLevelWasLoaded()
    {
        Time.timeScale = 1;
        previousScene = currentScene;
        currentScene = Application.loadedLevelName;
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Menu))
        {
            Application.Quit();
        }
    }

}
