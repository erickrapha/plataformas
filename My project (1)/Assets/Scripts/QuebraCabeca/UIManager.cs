using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private GameObject telaVitoria;
    
    void Awake()
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
