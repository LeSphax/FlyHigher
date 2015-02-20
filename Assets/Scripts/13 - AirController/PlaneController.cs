using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour
{

    public int rotatonSpeed;
    public int rotationDeceleration;
    public int movementSpeed;

    int rotationDirection;
    bool blocked;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationDirection) * Time.deltaTime * rotatonSpeed);
        if (!blocked)
        {
            Vector3 translation = Quaternion.Euler(transform.localEulerAngles) * Vector3.up * 1f;
            if (rotationDirection != 0)
            {
                transform.position += Time.deltaTime * movementSpeed / rotationDeceleration * translation;
            }
            else
            {
                transform.position += Time.deltaTime * movementSpeed * translation;
            }
        }
    }

    void TurnLeft()
    {
        rotationDirection = 1;
    }

    void TurnRight()
    {
        rotationDirection = -1;
    }

    void StopTurning()
    {
        rotationDirection = 0;
    }

    void Blocked()
    {
        blocked = true;
    }

    void UnBlocked()
    {
        blocked = false;
    }

}
