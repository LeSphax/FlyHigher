using UnityEngine;
using System.Collections;

public class RadarDot : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage("DotDestroyed");
        Destroy(gameObject);
    }
}
