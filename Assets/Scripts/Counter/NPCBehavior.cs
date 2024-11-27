using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
using System.IO;

public class NPCBehavior : MonoBehaviour
{
    public FoodObject desiredFood;
    [SerializeField]
    private float waitTime = 60;

    public static bool updateTime = true;

    [SerializeField]
    private string name = "Random";
    [SerializeField]
    private string[] dialog = new string[]
    {
        "Hello",
        "How are you?",
        "Can I have the "
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
        FindObjectOfType<DialogManager>().setDialog(name, dialog);
    }

    private void findFoodObject()
    {
        string folderPath = "Assets/ScriptableObjects/Food";  

        string[] assetPaths = Directory.GetFiles(folderPath, "*.asset");

        if (assetPaths.Length > 0)
        {
            string randomAssetPath = assetPaths[Random.Range(0, assetPaths.Length)];

            desiredFood = AssetDatabase.LoadAssetAtPath<FoodObject>(randomAssetPath);
        }
        else
        {
            Debug.LogWarning("No ScriptableObjects found in folder: " + folderPath);
        }

        dialog[dialog.Length-1] += desiredFood.name;
    }
}
