using UnityEngine;
using System.Collections;

public class LeftArrow : MonoBehaviour
{

    public GameObject plane;


    // Update is called once per frame
    void OnMouseEnter()
    {
        plane.SendMessage("TurnLeft");
    }

    void OnMouseExit()
    {
        plane.SendMessage("StopTurning");
    }
}
