using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUp : MonoBehaviour {

    PopUpHandler handler;

    public void SetText(string text, PopUpHandler handler)
    {
        Text myText = GetComponentInChildren<Text>();
        myText.text = text;
        this.handler = handler;
    }

    public void Exit()
    {
        handler.Exit();
        Destroy(gameObject);
    }

    public void Next()
    {
        handler.Next();
    }


}
