using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StirringGame : MonoBehaviour
{
    private FoodManager foodManager;

    [SerializeField]
    public static float minHoldTime = .5f, maxHoldTime = 1.5f,
        minBTWTime = .25f, maxBTWTime = .5f;
    [SerializeField]
    private float curTime, targetTime;
    [SerializeField]
    private bool holdEvent;

    public GameObject node;
    public Slider progreeSlider;

    [SerializeField]
    private float successfulPresses;
    [SerializeField]
    private float maxPresses;

    // Start is called before the first frame update
    void Awake()
    {
        foodManager = FindObjectOfType<FoodManager>();
        progreeSlider.maxValue = maxPresses;
        progreeSlider.value = 0;

        SetBTWTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTime <= curTime)
        {
            prompt();
        }
        else
        {
            curTime += Time.deltaTime;
        }
    }

    void SetBTWTime()
    {
        targetTime = Random.Range(minBTWTime, maxBTWTime);
        curTime = 0;
    }
    void SetBTWTime(float min)
    {
        targetTime = Random.Range(minBTWTime, maxBTWTime) + min;
        curTime = 0;
    }

    void prompt()
    {
        holdEvent = Random.Range(0, 101) <= 50;

        GameObject n = Instantiate(node);
        n.transform.SetParent(GameObject.Find("Canvas").transform);
        n.GetComponent<RectTransform>().anchoredPosition = node.GetComponent<RectTransform>().anchoredPosition;

        if (holdEvent)
        {
            float holdTime = Mathf.RoundToInt(Random.Range(minHoldTime, maxHoldTime));
            n.GetComponent<TimingNode>().setWidth(holdTime);
            SetBTWTime(holdTime);
        }
        else
        {
            SetBTWTime();
        }
    }

    public void addProgress(float progress)
    {
        successfulPresses += progress;
        if (successfulPresses < 0)
            successfulPresses = 0;

        progreeSlider.value = successfulPresses;

        if (successfulPresses >= maxPresses)
        {
            FindObjectOfType<InventoryManager>().addFood(foodManager.foodMade());
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
        }
    }
}
