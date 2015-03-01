using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{

    public int timer;
    float counter;
    public string sceneToLoad;
    // Use this for initialization
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > timer)
        {
            Application.LoadLevel(sceneToLoad);
        }
    }

}
