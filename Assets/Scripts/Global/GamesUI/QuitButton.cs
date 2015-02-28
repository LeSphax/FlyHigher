using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour
{

    public void QuitButtonPressed()
    {
        GameObject.FindWithTag("MainCamera").SendMessage("ReturnPressed");
    }
}
