using UnityEngine;
using System.Collections;

public class LeftArrow : MonoBehaviour
{

    public GameObject plane;


    // Update is called once per frame
    void OnMouseDown()
    {
        if (Time.timeScale != 0)
        {
            if (plane != null)
                plane.SendMessage("TurnLeft");
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
