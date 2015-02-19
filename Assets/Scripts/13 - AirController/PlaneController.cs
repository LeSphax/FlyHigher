using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour
{

    public int rotatonSpeed;
    public int rotationDeceleration;
    public int movementSpeed;
    bool rotating;

    void LateUpdate()
    {
        Vector3 translation = Quaternion.Euler(transform.localEulerAngles) * Vector3.up * 1f;
        if (rotating)
        {
            transform.position += Time.deltaTime * movementSpeed / rotationDeceleration * translation;
        }
        else
        {
            transform.position+= Time.deltaTime * movementSpeed * translation;
        }
        rotating = false;
    }

    void TurnLeft()
    {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotatonSpeed);
        rotating = true;
    }

    void TurnRight()
    {
        transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotatonSpeed);
        rotating = true;
    }
}
