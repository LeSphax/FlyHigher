using UnityEngine;
using System.Collections;

public abstract class IPopUpHandler : MonoBehaviour
{

    Object prefab = Resources.Load("Prefabs/00 - Global/StoryPopUp");
    GameObject popUp;
    PopUp popUpScript;
    System.Collections.Generic.Queue<string> texts;

    void Start()
    {
        texts = GetTexts();
        if (texts.Count > 0)
        {
            CreatePopUp(texts.Dequeue());
        }
    }

    protected abstract System.Collections.Generic.Queue<string> GetTexts();

    void CreatePopUp(string text)
    {
        popUp = Instantiate(prefab) as GameObject;
        popUpScript = popUp.GetComponent<PopUp>();
        SetText(text);
    }

    public void SetText(string text)
    {
        popUpScript.SetText(text,this);
    }

    public void DestroyPopUp()
    {
        popUpScript.Exit();
    }

    public void Next()
    {
        if (texts.Count > 0)
        {
            SetText(texts.Dequeue());
        }
        else
        {
            DestroyPopUp();
        }
    }
}
