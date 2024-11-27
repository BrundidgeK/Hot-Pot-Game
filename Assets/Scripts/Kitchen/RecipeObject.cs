using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New Recipe")]
public class RecipeObject : ScriptableObject
{
    public FoodObject[] ingredients;
    public FoodObject result;
}
