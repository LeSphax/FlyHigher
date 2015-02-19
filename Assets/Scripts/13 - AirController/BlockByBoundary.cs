using UnityEngine;
using System.Collections;

public class BlockByBoundary : MonoBehaviour {
    void OnTriggerStay(Collider other)
    {
        Debug.Log("collision");
    }
}
