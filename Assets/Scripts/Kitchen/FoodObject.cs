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

    public enum type
    {
        Meat,
        Vegetable,
        Fruit, 
        Grain,
        Sauce
    }
}