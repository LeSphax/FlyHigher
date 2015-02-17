using UnityEngine;
using System.Collections;

public class returnButton : MonoBehaviour {

    public string sceneToLoad;
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetKey(KeyCode.Escape)){
               if (sceneToLoad != null && sceneToLoad != "")
               {
                   Application.LoadLevel(sceneToLoad);
               }
               else
               {
                   Application.Quit();
               }
           
       }
	}
}
