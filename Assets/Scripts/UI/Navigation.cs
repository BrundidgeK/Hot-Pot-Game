using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    private Scene currentscene;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameplayScreen()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void LoadStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }
    public void LoadCuttingScreen()
    {
        SceneManager.LoadScene("CuttingGame");
    }
    public void LoadStirringScreen()
    {
        SceneManager.LoadScene("StirringGame");
    }

}
