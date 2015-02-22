using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    bool paused=false;

    public void PauseButtonClick()
    {
        if (paused)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        paused = true;
    }

    void UnPause()
    {
        Time.timeScale = 1;
        paused = false;
    }
}
