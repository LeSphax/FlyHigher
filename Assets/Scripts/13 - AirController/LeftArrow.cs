using UnityEngine;
using System.Collections;

public class LeftArrow : MonoBehaviour
{

    public GameObject plane;


    // Update is called once per frame
    void OnMouseDown()
    {
        if (plane != null)
        plane.SendMessage("TurnLeft");
    }

    void OnMouseUp()
    {
        if (plane != null)
        plane.SendMessage("StopTurning");
    }
}
