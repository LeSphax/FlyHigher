using UnityEngine;
using System.Collections;

public class OtherPlane : MonoBehaviour
{
    public int movementSpeed;   


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

    void Update()
    {
        Vector3 translation = Quaternion.Euler(transform.localEulerAngles) * Vector3.up * 1f;
        transform.position += Time.deltaTime * movementSpeed * translation;
    }
}
