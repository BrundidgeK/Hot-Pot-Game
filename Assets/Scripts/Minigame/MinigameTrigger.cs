using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField]
    private int miniGame;
    private Scene mini;

    private void Start()
    {
        try
        {
        mini = SceneManager.GetSceneAt(miniGame);
        }
        catch
        {
            Debug.LogError("Scene does not exists: " + gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        SceneManager.LoadSceneAsync(miniGame, LoadSceneMode.Additive);
    }
}
