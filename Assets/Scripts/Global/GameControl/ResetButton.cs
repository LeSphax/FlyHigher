using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

    public void Reset(){

        Application.LoadLevel(Application.loadedLevel);
        GameObject.FindWithTag("GameControl").SendMessage("Reset");
    }
}
