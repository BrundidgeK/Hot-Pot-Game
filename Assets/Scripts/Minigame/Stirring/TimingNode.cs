using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingNode : MonoBehaviour
{
    private RectTransform rectTrans;
    private Image image;

    private static int defaultWidth = 25;
    private static float moveSpeed = 250;

    public float holdTime = -1;
    public float curHold;

    private static float maxBufferTime = 2 * (defaultWidth/moveSpeed);
    private float curBuffer = 0;

    private bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, defaultWidth);
        image = GetComponent<Image>();
    }

    bool buttonDown;
    // Update is called once per frame
    void Update()
    {
        rectTrans.anchoredPosition = Vector2.MoveTowards(rectTrans.anchoredPosition, new Vector2(rectTrans.anchoredPosition.x-100, rectTrans.anchoredPosition.y), moveSpeed * Time.deltaTime);
        if(rectTrans.anchoredPosition.x <= defaultWidth && !complete)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                buttonDown = true;
                if (holdTime == -1) { 
                    image.color = Color.red;
                    FindObjectOfType<StirringGame>().addProgress(1);
                    complete = true;
                    Invoke("destroy", 5);
                }
            }
            else if (holdTime > 0 && buttonDown && Input.GetKey(KeyCode.Space))
            {
                curHold += Time.deltaTime;
                if (curHold >= holdTime - curBuffer)
                {
                    image.color = Color.red;
                    FindObjectOfType<StirringGame>().addProgress(1);
                    complete = true;
                    Invoke("destroy", 5);
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                FindObjectOfType<StirringGame>().addProgress(-1);
                Destroy(gameObject);
            }
            else
            {
                curBuffer += Time.deltaTime;
                if (curBuffer >= maxBufferTime)
                {
                    Destroy(gameObject);
                    FindObjectOfType<StirringGame>().addProgress(-1);
                }
            }
        }
    }

    public void setWidth(float holdTime)
    {
        rectTrans = GetComponent<RectTransform>();
        rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, defaultWidth);

        float scaleX = moveSpeed/defaultWidth * holdTime;
        rectTrans.localScale = new Vector3(scaleX, 1, 1);

        this.holdTime = holdTime;
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
