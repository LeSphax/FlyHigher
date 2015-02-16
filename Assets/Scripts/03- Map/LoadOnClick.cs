using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

    public string sceneToLoad;
    void OnMouseDown()
    {
        Application.LoadLevel(sceneToLoad);
    }



}
