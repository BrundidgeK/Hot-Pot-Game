using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    },
    wrongOrderDia = new string[]
    {
        "Um, I think you got my order wrong",
        "I ordered the "
    },
    rightOrderDia = new string[]
    {
        "Thank you!"
    };

    private Animator anim;
    private bool dialoging, orderComplete;

    void Awake()
    {
        /*if(desiredFood == null)
            findFoodObject();    */
        anim = GetComponent<Animator>();
        anim.enabled = false;
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

        if (dialoging)
        {
            dialoging = DialogManager.dialogActive;
        }
        else if (orderComplete)
        {
            FindObjectOfType<CustomerSpawning>().changeCount(-1, transform.position);
            Destroy(gameObject);
        }

        //anim.SetBool("Talking", dialoging);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; 
        }

        if (!DialogManager.dialogActive)
        {
            dialoging = true;
            DialogManager man = FindObjectOfType<DialogManager>();
            FoodObject selectedFood = FindObjectOfType<InventoryManager>().getSelectedFood();
            if (selectedFood == null)
            {
                man.setDialog(name, introDialog);
            }
            else
            {
                if (selectedFood.name.Equals(desiredFood.name))
                {
                    man.setDialog(name, rightOrderDia);
                    FindObjectOfType<InventoryManager>().clearSlot();
                    orderComplete = true;
                }
                else
                    man.setDialog(name, wrongOrderDia);
            }
        }
    }

    private void findFoodObject()
    {
        List<FoodObject> available = FindObjectOfType<Fridge>().getFoodList();
        desiredFood = available[Random.Range(0, available.Count)];
        introDialog[introDialog.Length - 1] += desiredFood.name;
        wrongOrderDia[wrongOrderDia.Length - 1] += desiredFood.name;
    }

    public void setDesiredFood(FoodObject food)
    {
        if (desiredFood != null)
            return;

        desiredFood = food;
        introDialog[introDialog.Length - 1] += desiredFood.name;
        wrongOrderDia[wrongOrderDia.Length - 1] += desiredFood.name;
    }

    public void changePosition()
    {
        transform.position -= (Vector3)FindObjectOfType<CustomerSpawning>().spacingBTWCust;
    }
}
