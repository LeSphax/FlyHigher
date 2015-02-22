using UnityEngine;
using System.Collections;

public class RadarDot : MonoBehaviour
{
    public AudioClip collectSound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerPlane")
        {
            other.gameObject.SendMessage("DotDestroyed");
            Destroy(gameObject);
            if (collectSound)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
    }
}
