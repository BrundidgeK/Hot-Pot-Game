using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public FoodObject desiredFood;
    [SerializeField]
    private float waitTime = 60;

    public static bool updateTime = true;

    [SerializeField]
    private string name = "Random";

    [Header("Dialog")]
    [SerializeField]
    private string[] introDialog = new string[]
    {
        "Hello",
        "How are you?",
        "Can I have the "
    };
    [SerializeField]
    private string[] wrongOrderDia = new string[]
    {
        "Um, I think you got my order wrong",
        "I ordered the "
    };
    [SerializeField]
    private string[] rightOrderDia = new string[]
    {
        "Thank you!"
    };

    void Awake()
    {
        if(desiredFood == null)
            findFoodObject();    
    }

    // Update is called once per frame
    void Update()
    {
        if(updateTime)
            waitTime -= Time.deltaTime;
        if( waitTime <= 0)
        {
            Debug.Log("Uh oh");
        }
    }

    private void OnMouseDown()
    {
        DialogManager man = FindObjectOfType<DialogManager>();
        FoodObject selectedFood = FindObjectOfType<InventoryManager>().getSelectedFood();
        if(selectedFood == null)
        {
            man.setDialog(name, introDialog);
        }
        else
        {
            if (selectedFood.name.Equals(desiredFood.name))
            {
                man.setDialog(name, rightOrderDia);
                FindObjectOfType<InventoryManager>().getCurrentSlot().changeFood(null);
                Destroy(gameObject);
            }
            else
                man.setDialog(name, wrongOrderDia);
        }

    }

    private void findFoodObject()
    {
        List<FoodObject> available = FindObjectOfType<Fridge>().getFoodList();
        desiredFood = available[Random.Range(0, available.Count)];
        introDialog[introDialog.Length - 1] += desiredFood.name;
        wrongOrderDia[wrongOrderDia.Length - 1] += desiredFood.name;
    }
}
