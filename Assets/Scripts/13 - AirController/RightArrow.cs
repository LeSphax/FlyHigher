using UnityEngine;
using System.Collections;

public class RightArrow : MonoBehaviour
{

    public GameObject plane;


    void OnMouseDown()
    {
        if (Time.timeScale != 0)
        {
            if (plane != null)
                plane.SendMessage("TurnRight");
        }
    }

    void OnMouseUp()
    {
        if (Time.timeScale != 0)
        {
            if (plane != null)
                plane.SendMessage("StopTurning");
        }
    }
}
