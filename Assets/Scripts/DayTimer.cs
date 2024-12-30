using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimer : MonoBehaviour
{
    [SerializeField]
    private float dayCycle = 180;

    public static float curTime;

    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= dayCycle)
        {
            //End day
        }
    }
}
