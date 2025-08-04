using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button resetPuzzle;
    public static UIManager instance;
    
    private bool puzzleCompleted = false;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private Text victoryText;
    [SerializeField] private Button restartPuzzle;
    [SerializeField] private Button replay;

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
        resetPuzzle.onClick.AddListener(ResetPuzzle);
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
        victoryScreen.SetActive(true);
        /*victoryText.text.SetActive(true);
        restartPuzzle.button.SetActive(true);
        replay.button.SetActive(true);*/
        Time.timeScale = 0f;
    }
    public void ResetPuzzle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
