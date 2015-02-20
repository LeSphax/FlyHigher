using UnityEngine;
using System.Collections;

public class BlockByBoundary : MonoBehaviour {

    public GameObject plane;
    int i=0;
    void OnTriggerEnter2D(Collider2D other)
    {
        plane.SendMessage("UnBlocked");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        plane.SendMessage("Blocked");
    }
}
