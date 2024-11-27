using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text nameTag;
    [SerializeField]
    private TMP_Text dialog;

    private Queue<string> lines = new Queue<string>();

    public void setDialog(string name, string[] dialog)
    {
        activate(true);
        nameTag.text = name;
        foreach (string s in dialog)
        {
            lines.Enqueue(s);
        }
        continueDialog();

        NPCBehavior.updateTime = false;
    }

    public void continueDialog()
    {
        if (lines.Count == 0)
        {
            cancel();
            return;
        }
        dialog.text = lines.Dequeue();
    }

    private void cancel()
    {
        NPCBehavior.updateTime = true;
        activate(false);
    }

    private void activate(bool a)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(a);
        }
    }
}
