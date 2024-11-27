using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Button button;
    private TMP_Text text;
    public FoodObject food;

    private Color normal = new Color(255, 255, 255), selected = new Color(50, 50, 50);

    private void Start()
    {
        button = GetComponent<Button>();
        text = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    public void changeFood(FoodObject food)
    {
        this.food = food;
        text.text = food.name;
    }

    public bool hasFood() { return this.food != null; }

    public void selectPlate(bool select)
    {
        button.image.color = select ? selected : normal;
        if (select)
        {
            InventoryManager man = FindAnyObjectByType<InventoryManager>();
            man.selectPlate(this);
        }
    }
}
