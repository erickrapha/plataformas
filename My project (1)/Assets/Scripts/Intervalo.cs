using UnityEngine;
using UnityEngine.SceneManagement;

public class Intervalo : MonoBehaviour
{
    public float intervaloTempo = 2.0f;
    public string newScene = "MainMenu";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Carregado", intervaloTempo);
    }

    // Update is called once per frame
    void Carregado()
    {
        GameManager.instance.LoadScene(newScene);
    }
}
