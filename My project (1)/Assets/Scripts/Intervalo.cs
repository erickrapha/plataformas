using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Intervalo : MonoBehaviour
{
    public float intervaloTempo = 2f;
    public string newScene = "MainMenu";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Carregamento()
    {
        StartCoroutine(CarregarCenaComDelayCoroutine());
    }
    private IEnumerator CarregarCenaComDelayCoroutine()
    {
        yield return new WaitForSeconds(intervaloTempo);
        SceneManager.LoadScene(newScene);
    }
}
