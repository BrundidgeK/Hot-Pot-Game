using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]
    private RecipeObject[] availableRecipes;

    private List<FoodObject> foods = new List<FoodObject>();

    public void addFood(FoodObject food)
    {
        if(!foods.Contains(food)) 
            foods.Add(food);
    }

    public FoodObject foodMade()
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
                return r.result;
            }
        }

        return null;
    }
}