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
            count++;
            if (count == 1)
            {
                ActivateFlashing();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "OtherPlane")
        {
            count--;
            if (count == 0)
            {
                DesactivateFlashing();
            }
        }
    }

    // This way this method can be called using BroadcastMessage
    void ActivateFlashing()
    {
        gameUI.BroadcastMessage("ActivateFlashing");
    }

    // This way this method can be called using BroadcastMessage
    void DesactivateFlashing()
    {
        gameUI.BroadcastMessage("DesactivateFlashing");
    }

}
