using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //SceneManager.LoadScene("Splash");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadGameAndGUI()
    {
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
    }

    private void Start()
    {
        SceneManager.LoadScene("Splash");
    }

    public void LoadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
    
}
