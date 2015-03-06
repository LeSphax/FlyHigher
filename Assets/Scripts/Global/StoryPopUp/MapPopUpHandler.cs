using UnityEngine;
using System.Collections;

public class MapPopUpHandler : PopUpHandler {

    public string id;

    protected override System.Collections.Generic.Queue<string> GetTexts()
    {
        return GetTexts(id);
    }
}
