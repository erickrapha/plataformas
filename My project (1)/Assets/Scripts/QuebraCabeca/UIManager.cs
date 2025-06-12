using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    
    [SerializeField] private GameObject telaVitoria;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ShowVictoryScreen()
    {
        telaVitoria.SetActive(true);
    }
}
