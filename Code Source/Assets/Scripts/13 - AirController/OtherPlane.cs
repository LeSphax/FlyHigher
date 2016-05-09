using UnityEngine;
using System.Collections;

public class OtherPlane : MonoBehaviour
{
    public int movementSpeed;
    GameObject NearbyPlaneDetection;
    bool moving;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NearbyPlaneDetection")
        {
            NearbyPlaneDetection = other.gameObject;
        }
        else if (other.tag == "PlayerPlane" && moving)
        {
            other.gameObject.SendMessage("CollisionWithAirplane");
            Destroy(gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "NearbyPlaneDetection")
        {
            NearbyPlaneDetection = null;
        }
        if (other.tag == "Radar")
        {
            if (NearbyPlaneDetection != null)
            {
                NearbyPlaneDetection.SendMessage("OtherPlaneExited");
            }
            Destroy(gameObject);
        }
    }

    void Start()
    {
        moving = false;
        Invoke("BeginMoving", 2);
    }

    void BeginMoving()
    {
        moving = true;
        gameObject.GetComponent<Animation>().Stop();
        GetComponent<Renderer>().enabled = true;
    }
    void Update()
    {
        if (moving)
        {
            Vector3 translation = Quaternion.Euler(transform.localEulerAngles) * Vector3.up * 1f;
            transform.position += Time.deltaTime * movementSpeed * translation;
        }
    }
}
