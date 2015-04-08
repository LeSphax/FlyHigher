using UnityEngine;
using System.Collections;

public class BeginningPopUpHandler : PopUpHandler {

    public string idBeginning;


    protected override void Start(){
        texts = GetTexts(idBeginning);
    }

    protected override System.Collections.Generic.Queue<string> GetTexts()
    {
        return GetTexts(idBeginning);
    }

    public void PopUpAppear()
    {
        CreatePopUp(texts.Dequeue());
    }

    public override void Next()
    {
        if (texts.Count > 0)
        {
            SetText(texts.Dequeue());
        }
        else
        {
            Application.LoadLevel("Map");
        }
    }

}
