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
        slots = FindObjectsOfType<InventorySlot>();
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
        InventorySlot old = selected;
        selected = slot;
        if (old != null)
            old.selectPlate(false);
    }

    public FoodObject getSelectedFood()
    {
        if (selected != null)
            return selected.food;
        return null;
    }

    public InventorySlot getCurrentSlot()
    {
        return selected;
    }

    public void clearSlot()
    {
        selected.changeFood(null);
    }
}
