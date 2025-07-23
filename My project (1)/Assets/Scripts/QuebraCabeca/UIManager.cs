using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    private bool puzzleCompleted = false;
    [SerializeField] private GameObject victoryScreen;
    
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
    private bool CheckPuzzleCompletion()
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
