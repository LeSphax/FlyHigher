using UnityEngine;
using System.Collections;

public class LeftArrow : MonoBehaviour
{

    public GameObject plane;


    // Update is called once per frame
    void OnMouseOver()
    {
        plane.SendMessage("TurnLeft");
    }
}
