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

    private Color normal = new Color(1, 1, 1, 0), selected = new Color(1, 1, 1, .3f);
    [SerializeField]
    private bool selectedPlate;
    InventoryManager man;

    private void Start()
    {
        man = FindObjectOfType<InventoryManager>();
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    public void changeFood(FoodObject food)
    {
        this.food = food;
        text.text = food == null ? "Empty" : food.name;
        if (food == null) selectPlate(false);
    }

    public bool hasFood() { return this.food != null; }

    public void selectPlate(bool sel)
    {
        selectedPlate = sel;
        if (selectedPlate)
            man.selectPlate(this);
        else if(man.getCurrentSlot() == this)
            man.selectPlate(null);

        image.color = selectedPlate ? selected : normal;
    }
}
