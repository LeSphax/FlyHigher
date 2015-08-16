using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelFlashing : MonoBehaviour
{
    Image image;
    bool flashing;

    void Start()
    {
        image = GetComponent<Image>();
        flashing = false;
    }

    public void ActivateFlashing()
    {
        audio.Play();
        flashing = true;
        Flash();
    }

    public void DesactivateFlashing()
    {
        audio.Stop();
        flashing = false;
    }

    void Flash()
    {
        if (flashing)
        {
            if (image.color == Color.clear)
                image.color = new Color(1.0f, 0, 0, 0.2f);
            else
                image.color = Color.clear;
            Invoke("Flash", 0.5f);
        }
        else
        {
            image.color = Color.clear;
        }
    }

    void GameEnded()
    {
        DesactivateFlashing();
    }
}
