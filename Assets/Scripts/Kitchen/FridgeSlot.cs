using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FridgeSlot : MonoBehaviour
{
    [SerializeField]
    private FoodObject.type type;
    private TMP_Text typeText, foodText;
    public FoodObject food;

    private Fridge fridge;
    int index = 0;

    private void Start()
    {
        typeText = transform.GetChild(1).GetComponent<TMP_Text>();
        foodText = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        typeText.text = type.ToString();

        fridge = FindObjectOfType<Fridge>();

        food = fridge.getFood(type, index);
        foodText.text = food.name;
    }

    public void NextInList()
    {
        index++;
        if (index == fridge.listLength(type))
            index = 0;
        food = fridge.getFood(type, index);
        foodText.text = food.name;
    }

    public void foodInInventory()
    {
        FindObjectOfType<InventoryManager>().addFood(food);
    }
}
