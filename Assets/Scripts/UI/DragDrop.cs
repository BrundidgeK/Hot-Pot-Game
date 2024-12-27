using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 mouseposoffset;

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mouseposoffset = gameObject.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + mouseposoffset;
    }
    private void OnMouseUp()
    {
        if(gameObject.transform.position.x < 2 && -2 < gameObject.transform.position.x) 
        {
            if (gameObject.transform.position.y < 2 && -2 < gameObject.transform.position.y)
            { 
                gameObject.transform.position = new Vector3(0, 0, 0);
            }
        }
    }
}
