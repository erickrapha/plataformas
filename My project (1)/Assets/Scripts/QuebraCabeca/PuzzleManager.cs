using UnityEngine;
using static UnityEngine.Debug;

public class PuzzleManager : MonoBehaviour
{
    public PecaClicavel puzzlePiece;
    public PecaClicavel puzzlePiece1;
    public PecaClicavel puzzlePiece2;
    public PecaClicavel puzzlePiece3;
    public PecaClicavel puzzlePiece4;
    public PecaClicavel puzzlePiece5;
    public PecaClicavel puzzlePiece6;
    public PecaClicavel puzzlePiece7;
    public PecaClicavel puzzlePiece8;
    public PecaClicavel puzzlePiece9;
    public PecaClicavel puzzlePiece10;
    public PecaClicavel puzzlePiece11;
    public PecaClicavel puzzlePiece12;
    public PecaClicavel puzzlePiece13;
    public PecaClicavel puzzlePiece14;
    public PecaClicavel puzzlePiece15;
    
    [SerializeField] private PuzzlePiece[] puzzlePieces;
    public bool puzzleCompleted = false;

    void Start()
    {
        OnPuzzleCompleted();
    }
    
    // Update is called once per frame
    public void Update()
    {
        if (!puzzleCompleted && CheckPuzzleCompletion())
        {
            puzzleCompleted = true;
            OnPuzzleCompleted();
        }
    }
    private bool CheckPuzzleCompletion()
    {
        foreach (var piece in puzzlePieces)
        {
            if (!piece.IsCorrectlyPlaced)
                return false;
        }
        return true;
    }
    public static void OnPuzzleCompleted()
    {
        Debug.Log(message: "Puzzle terminado");
        UIManager.instance.ShowVictoryScreen();
    }

}


