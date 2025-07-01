using UnityEngine;
using System;
using static UnityEngine.Debug;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PecaClicavel[] puzzlePieces;
    
    public bool puzzleCompleted = false;
    
    public void Start()
    {
        QuebraCabeca.Embaralhar(puzzlePieces);
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
            //if (!piece.IsCorrectlyPlaced)
                return false;
        }
        return true;
    }
    public static void OnPuzzleCompleted()
    {
        Debug.Log("Puzzle terminado");
        UIManager.instance.ShowVictoryScreen();
    }

}


