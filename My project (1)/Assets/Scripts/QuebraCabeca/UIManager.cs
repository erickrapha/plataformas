using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private GameObject victoryScreen;
    public bool puzzleCompleted = false;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void OnPiecePlacedCorrectly()
    {
        if(!puzzleCompleted && CheckPuzzleCompletion())
        {
            puzzleCompleted = true;
            ShowVictoryScreen();
        }
    }
    public bool CheckPuzzleCompletion()
    {
        return true;
    }
    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResetPuzzle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
