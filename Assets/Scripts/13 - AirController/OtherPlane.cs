using UnityEngine;
using System.Collections;

public class OtherPlane : MonoBehaviour
{
    public int movementSpeed;
    bool moving;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerPlane")
        {
            other.gameObject.SendMessage("CollisionWithAirplane");
            Destroy(gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Radar")
        {
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
        gameObject.animation.Stop();
        renderer.enabled = true;
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
