using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

    public void Reset(){
        GameObject.FindWithTag("GameControl").SendMessage("Reset");
    }
}
