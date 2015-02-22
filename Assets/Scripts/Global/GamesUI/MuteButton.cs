using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {
    bool muted=false;

    public void MuteButtonPress()
    {
        if (muted)
        {
            UnMute();
        }
        else
        {
            Mute();
        }
    }

    void Mute()
    {
        AudioListener.pause = true;
        muted = true;
    }

    void UnMute()
    {
        AudioListener.pause = false;
        muted = false;
    }
}
