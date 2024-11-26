using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    private void OnMouseDown()
    {
        ui.SetActive(true);
    }
}
