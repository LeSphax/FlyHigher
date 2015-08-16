using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteButton : MonoBehaviour
{
    GameData gameData;

    private const float MAX_VOLUME = 1.0f;

    enum State { UnMuted, Muted };
    State state;
    Image imageScript;

    Sprite baseImage;
    public Sprite activationImage;

    void Awake()
    {
        imageScript = GetComponent<Image>();
        
        gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
    }
    void Start()
    {
        Init();
    }

    void Init()
    {
        baseImage = imageScript.sprite;
        if (gameData.volume == 0)
        {
            Mute();
            state = State.Muted;
            imageScript.sprite = activationImage;
        }
        else
        {
            UnMute();
            state = State.UnMuted;
            imageScript.sprite = baseImage;
        }
    }

    public void OnButtonPressed()
    {
        switch (state)
        {
            case State.UnMuted:
                state = State.Muted;
                imageScript.sprite = activationImage;
                Mute();
                break;
            case State.Muted:
                state = State.UnMuted;
                imageScript.sprite = baseImage;
                UnMute();
                break;
        }
    }

    void Mute()
    {
        AudioListener.volume = 0;
        gameData.volume = 0;
    }

    void UnMute()
    {
        AudioListener.volume = MAX_VOLUME;
        gameData.volume = MAX_VOLUME;
    }
}
