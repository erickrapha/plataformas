using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private GameObject victoryScreen;
    private bool puzzleComplete = false;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void OnPiecePlacedCorrectly()
    {
        if(!puzzleComplete && CheckPuzzleCompletion())
        {
            puzzleComplete = true;
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
