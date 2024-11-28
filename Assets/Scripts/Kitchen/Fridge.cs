using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField]
    private List<FoodObject> foods;

    private Dictionary<string, List<FoodObject>> assortedTypes;

    // Start is called before the first frame update
    void Awake()
    {
        assortedTypes = new Dictionary<string, List<FoodObject>>();
        foreach(var name in Enum.GetNames(typeof(FoodObject.type)))
        {
            assortedTypes.Add(name, new List<FoodObject>());
        }
        foreach(var food in foods)
        {
            assortedTypes[food.foodType.ToString()].Add(food);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addFoodInFridge(FoodObject food)
    {
        foods.Add(food);
        assortedTypes[food.foodType.ToString()].Add(food);
    }

    public FoodObject getFood(FoodObject.type foodType, int index) {
        return assortedTypes[foodType.ToString()][index];
    }

    public int listLength(FoodObject.type foodType)
    {
        return assortedTypes[foodType.ToString()].Count;
    }

    public List<FoodObject> getFoodList()
    {
        return foods;
    }
}
