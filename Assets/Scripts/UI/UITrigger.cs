using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        ui.SetActive(true);
    }
}
