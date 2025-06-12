using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] static private GameObject vitoryScreen;
    private bool puzzleComplete = false;
    
    private void Awake()
    {
        CheckPuzzleCompletion();
        if (instance == null)
        {
            instance = this;
        }
    }
    /*public void CheckVictoryCondition(CheckPuzzleCompletion() && !puzzleComplete)
    {
        puzzleComplete = true;
        ShowVictoryScreen();
    }*/
    public static void ShowVictoryScreen()
    {
        vitoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    bool CheckPuzzleCompletion()
    {
        return true;
    }
    void OnPiecePlacedCorrectly()
    {
        CheckPuzzleCompletion();
    }
    public void ResetPuzzle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
