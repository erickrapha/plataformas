using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Canvas canvas;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    public void /*Update*/ LoadGameAndGUI()
    {
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
        /*Destroy(canvas.gameObject, 2.0f);
        SceneManager.LoadScene("MainMenu");*/
    }

    private void Start()
    {
        LoadGameAndGUI();
    }
    /*void LateUpdate()
    {
        if()
        {
            
        }
        if ()
        {
            SceneManager.LoadScene("Game");
        }
        
    }*/
}
