using UnityEngine;
using System.Collections;

public class ImminentCollision : MonoBehaviour {

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
                gameUI.BroadcastMessage("ActivateFlashing");
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
                gameUI.BroadcastMessage("DesactivateFlashing");
            }
        }
    }

}
