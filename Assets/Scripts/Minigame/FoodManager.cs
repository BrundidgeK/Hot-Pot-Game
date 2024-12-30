using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]
    private RecipeObject[] availableRecipes;

    private List<FoodObject> foods = new List<FoodObject>();
    private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        inventoryManager.selectPlate(null);
    }

    private void Update()
    {
        if(inventoryManager.getCurrentSlot() != null)
        {
            addFood(inventoryManager.getSelectedFood());
            inventoryManager.clearSlot();
        }
    }

    public void addFood(FoodObject food)
    {
        if(!foods.Contains(food)) 
            foods.Add(food);
    }

    public FoodObject foodMade(float quality)
    {
        foreach (RecipeObject r in availableRecipes)
        {
            if (r.ingredients.Length != foods.Count)
                continue;

            int sameFood = 0;
            foreach (FoodObject f in r.ingredients)
            {
                if (foods.Contains(f))
                {
                    sameFood++;
                }
            }

            if(sameFood == r.ingredients.Length)
            {
                FoodObject result = r.result;
                result.Stars = quality == 0 ? 3 : Mathf.RoundToInt(quality);
                return result;
            }
        }

        return null;
    }
}