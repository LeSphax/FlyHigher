﻿using UnityEngine;
using System.Collections;

public class buttonLoadScene : MonoBehaviour {

    public string sceneToLoad;
	// Use this for initialization
    public void loadScene()
    {
        Application.LoadLevel(sceneToLoad);
    }
}
