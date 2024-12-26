
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomerSpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject customerPrefab, parent;

    public Vector2 startLine;
    public Vector2 spacingBTWCust;

    [SerializeField]
    private int maxCount, currentCount;

    [SerializeField] private float timeBTWSpawn, timeElasped;

    [SerializeField]
    private AnimatorOverrideController[] animationControllers;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentCount < maxCount)
        {
            timeElasped += Time.fixedDeltaTime;
            if (timeElasped >= timeBTWSpawn)
            {
                Spawn();
                timeElasped = 0;
            }
        }
    }

    private void Spawn()
    {
        AnimatorOverrideController aoc = animationControllers[Random.Range(0, animationControllers.Length)];
        Vector2 position = startLine + spacingBTWCust * currentCount;
        GameObject customer = Instantiate(customerPrefab, position, Quaternion.identity);
        customer.GetComponent<Animator>().runtimeAnimatorController = aoc;
        customer.transform.parent = parent.transform;

        changeCount(1);
    }

    public void changeCount(int count)
    {
        currentCount += count;
    }

    public void changeCount(int count, Vector3 missing)
    {
        changeCount(count);
        NPCBehavior[] npcs = FindObjectsOfType<NPCBehavior>();
        Vector2 norm = spacingBTWCust.normalized;
        foreach (NPCBehavior npc in npcs)
        {
            Vector2 diff = (npc.transform.position - missing).normalized;
            if (diff == norm)
                npc.changePosition();
        }
    }
}