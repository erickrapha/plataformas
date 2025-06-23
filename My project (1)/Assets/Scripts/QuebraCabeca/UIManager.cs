using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] public GameObject vitoryScreen;
    public bool puzzleComplete = false;
    
    private void Awake()
    {
        CheckPuzzleCompletion();
        if (instance == null)
        {
            instance = this;
        }
    }
    public void CheckVictoryCondition()
    {
        CheckVictoryCondition();
    }
    /*public void CheckVictoryCondition(CheckPuzzleCompletion && !puzzleComplete)
    {
        puzzleComplete = true;
        ShowVictoryScreen();
    }*/
    public void ShowVictoryScreen()
    {
        vitoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public bool CheckPuzzleCompletion()
    {
        return true;
    }
    public void OnPiecePlacedCorrectly()
    {
        CheckPuzzleCompletion();
    }
    public void ResetPuzzle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
public abstract class CheckPuzzleCompletion
{
    
}
