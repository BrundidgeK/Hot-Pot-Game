using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private InventorySlot[] slots;
    [SerializeField]
    private InventorySlot selected;

    void Start()
    {
        slots = GetComponentsInChildren<InventorySlot>();
    }

    public void addFood(FoodObject food)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].hasFood())
            {
                slots[i].changeFood(food);
                break;
            }
        }
    }

    public void selectPlate(InventorySlot slot)
    {
        if(selected  != null) 
            selected.selectPlate(false);
        selected = slot;
    }
}
