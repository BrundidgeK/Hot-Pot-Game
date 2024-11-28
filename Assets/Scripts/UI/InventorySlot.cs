using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image image;
    private TMP_Text text;
    public FoodObject food;

    private Color normal = new Color(1, 1, 1), selected = new Color(.75f, .75f, .75f);
    [SerializeField]
    private bool selectedPlate;

    private void Start()
    {
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    public void changeFood(FoodObject food)
    {
        this.food = food;
        text.text = food == null ? "Empty" : food.name;
    }

    public bool hasFood() { return this.food != null; }

    public void selectPlate()
    {
        selectedPlate = !selectedPlate;
        InventoryManager man = FindObjectOfType<InventoryManager>();
        if (selectedPlate)
        {
            man.selectPlate(this);
        }
        else
        {
            man.selectPlate(null);
        }
        image.color = selectedPlate ? selected : normal;
    }

    public void deselectPlate()
    {
        selectedPlate = false;
        image.color = normal;
    }
}
