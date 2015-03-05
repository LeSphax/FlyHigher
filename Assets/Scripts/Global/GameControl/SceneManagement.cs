using UnityEngine;
using System.Collections;

public class SceneManagement : MonoBehaviour
{
    string previousScene;
    string currentScene;

    public string PreviousScene
    {
        get{
            return previousScene;
        }
    }

    public string CurrentScene
    {
        get{
            return currentScene;
        }
    }
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
