using UnityEngine;
using System.Collections;

public class RightArrow : MonoBehaviour
{

    public GameObject plane;


    void OnMouseDown()
    {
        if (plane != null)
        plane.SendMessage("TurnRight");
    }

    void OnMouseUp()
    {
        if (plane != null)
        plane.SendMessage("StopTurning");
    }
}
