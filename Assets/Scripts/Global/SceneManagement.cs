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
        previousScene = null;
        currentScene = null;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (previousScene != null)
            {
                Application.LoadLevel(previousScene);
            }
            else
            {
                Application.Quit();
            }
        }
        if (Input.GetKey(KeyCode.Menu))
        {
            Application.Quit();
        }
    }

}
