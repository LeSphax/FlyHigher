using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUp : MonoBehaviour {

    IPopUpHandler handler;

    public void SetText(string text, IPopUpHandler handler)
    {
        Text myText = GetComponentInChildren<Text>();
        myText.text = text;
        this.handler = handler;
    }

    public void Exit()
    {
        Destroy(gameObject);
    }

    public void Next()
    {
        handler.Next();
    }


}
