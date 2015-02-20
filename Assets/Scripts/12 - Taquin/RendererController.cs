using UnityEngine;
using System.Collections;

public class RendererController : MonoBehaviour
{

    void DisableRenderer()
    {
        if (gameObject.GetComponent<Renderer>() != null){
            gameObject.GetComponent<Renderer>().enabled=false;
        }
    }

    void EnableRenderer()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
