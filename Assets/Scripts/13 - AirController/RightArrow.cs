using UnityEngine;
using System.Collections;

public class RightArrow : MonoBehaviour
{

    public GameObject plane;


    void OnMouseEnter()
    {
        plane.SendMessage("TurnRight");
    }

    void OnMouseExit()
    {
        plane.SendMessage("StopTurning");
    }
}
