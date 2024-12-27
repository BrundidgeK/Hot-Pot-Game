using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    Vector3 startpoint;
    Vector3 endpoint;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        startpoint = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        endpoint = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Debug.DrawLine(Input.mousePosition, startpoint, Color.red);
    }
}
