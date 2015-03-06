using UnityEngine;
using System.Collections;

public abstract class IPopUpHandler : MonoBehaviour
{

    Object prefab = Resources.Load("Prefabs/00 - Global/StoryPopUp");
    GameObject popUp;
    PopUp popUpScript;

    void CreatePopUp()
    {
        popUp = Instantiate(prefab) as GameObject;
        popUpScript = popUp.GetComponent<PopUp>();
    }

    public abstract void Next();
}
