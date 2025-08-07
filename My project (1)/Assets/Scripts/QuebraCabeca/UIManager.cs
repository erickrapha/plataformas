using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button resetPuzzleButton;
    public Button desfazerButton;
    public static UIManager instance;
    
    private bool puzzleCompleted = false;
    [SerializeField] private GameObject victoryScreen;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        resetPuzzleButton.onClick.AddListener(ResetPuzzle);
    }
    public void OnPiecePlacedCorrectly()
    {
        if(!puzzleCompleted)
        {
            puzzleCompleted = true;
            ShowVictoryScreen();
        }
    }
    public void ShowVictoryScreen()
    {
        Time.timeScale = 0f;
        victoryScreen.SetActive(true);
        if (desfazerButton != null)
            desfazerButton.gameObject.SetActive(false);
    }
    public void ResetPuzzle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
