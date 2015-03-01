using UnityEngine;
using System.Collections;

public class ImminentCollision : MonoBehaviour
{

    public GameObject gameUI;
    int count;

    void Start()
    {
        count = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OtherPlane")
        {
            OtherPlaneEntered();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "OtherPlane")
        {
            OtherPlaneExited();
        }
    }

    void OtherPlaneEntered()
    {
        count++;
        if (count == 1)
        {
            gameUI.BroadcastMessage("ActivateFlashing");
        }
    }

    void OtherPlaneExited()
    {
        count--;
        if (count == 0)
        {
            gameUI.BroadcastMessage("DesactivateFlashing");
        }
    }

}
