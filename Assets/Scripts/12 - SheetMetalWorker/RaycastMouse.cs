using UnityEngine;
using System.Collections;

public class RaycastMouse : MonoBehaviour
{

    GameObject hoveredGO;

    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // OnMouseDown
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                hitInfo.collider.SendMessage("MousePress", SendMessageOptions.DontRequireReceiver);
            }
        }

        // OnMouseUp
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                hitInfo.collider.SendMessage("MouseRelease", SendMessageOptions.DontRequireReceiver);
            }
        }

        // OnMouseOver
        if (Physics.Raycast(ray, out hitInfo))
        {
            hitInfo.collider.SendMessage("MouseOver", SendMessageOptions.DontRequireReceiver);
        }

        // OnMouseEnter
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject != hoveredGO)
            {
                hitInfo.collider.SendMessage("MouseEnter", SendMessageOptions.DontRequireReceiver);
                hoveredGO = hitInfo.collider.gameObject;
            }
        }
    }
}
