using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Food")]
public class FoodObject : ScriptableObject
{
    public string name;
    public string description;
    public Sprite sprite;
    public type foodType;
    private int starRating = 3;
    public int Stars
    {
        get { return starRating; }
        set { starRating = value; }
    }

    public enum type
    {
        Meat,
        Vegetable,
        Fruit, 
        Grain,
        Sauce
    }
}