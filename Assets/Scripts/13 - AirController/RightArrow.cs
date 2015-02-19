using UnityEngine;
using System.Collections;

public class RightArrow : MonoBehaviour
{

    public GameObject plane;


    // Update is called once per frame
    void OnMouseOver()
    {
        plane.SendMessage("TurnRight");
    }
}
