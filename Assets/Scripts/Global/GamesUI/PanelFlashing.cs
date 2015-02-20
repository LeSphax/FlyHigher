using UnityEngine;
using System.Collections;

public class PanelFlashing : MonoBehaviour
{

    public GameObject panel;
    public GameObject audio;
    bool flashing;

    void Start()
    {
        flashing = false;
    }

    public void ActivateFlashing()
    {
        audio.SetActive(true);
        flashing = true;
        Flash();
    }

    public void DesactivateFlashing()
    {
        audio.SetActive(false);
        flashing = false;
    }

    void Flash()
    {
        if (flashing)
        {
            if (panel.activeSelf)
                panel.SetActive(false);
            else
                panel.SetActive(true);
            Invoke("Flash", 0.5f);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
