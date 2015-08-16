using UnityEngine;
using System.Collections;

public class BlockByBoundary : MonoBehaviour {

    public GameObject plane;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerPlane")
        {
            other.SendMessage("UnBlocked");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerPlane")
        {
            other.SendMessage("Blocked");
        }
    }
}
