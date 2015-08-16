using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject pauseButton;

    public void PauseButtonPressed()
    {
        pauseButton.SendMessage("OnButtonPressed");
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
