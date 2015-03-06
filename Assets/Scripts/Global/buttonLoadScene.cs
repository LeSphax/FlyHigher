using UnityEngine;
using System.Collections;

public class buttonLoadScene : MonoBehaviour {

    public string sceneToLoad;

    public void loadScene()
    {
        Application.LoadLevel(sceneToLoad);
    }
}
