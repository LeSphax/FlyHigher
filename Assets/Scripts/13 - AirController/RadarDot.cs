using UnityEngine;
using System.Collections;

public class RadarDot : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerPlane")
        {
            other.gameObject.SendMessage("DotDestroyed");
            Destroy(gameObject);
        }
    }
}
