using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TwoStatesButton : MonoBehaviour
{

    enum State { Rest, Activated };
    State state;
    Image imageScript;

    Sprite baseImage;
    public Sprite activationImage;

    void Awake()
    {
        imageScript = GetComponent<Image>();
    }
    // Use this for initialization
    void Start()
    {
        Init();
    }

    void Init()
    {
        state = State.Rest;
        baseImage = imageScript.sprite;

    }

    public void OnButtonPressed()
    {
        switch (state)
        {
            case State.Rest:
                state = State.Activated;
                imageScript.sprite = activationImage;
                break;
            case State.Activated:
                state = State.Rest;
                imageScript.sprite = baseImage;
                break;
        }
    }
}
