using UnityEngine;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using static UnityEngine.Debug;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PecaClicavel> puzzlePieces;
    public Transform gridPanel;
    
    public bool isPuzzleCompleted = false;
    
    void Start()
    {
        QuebraCabeca.Embaralhar(puzzlePieces, gridPanel);
    }
    public void Update()
    {
        if (!isPuzzleCompleted && CheckPuzzleCompletion())
        {
            isPuzzleCompleted = true;
            Debug.Log("O Puzzle está completo");
        }
    }
    public bool CheckPuzzleCompletion()
    {
        foreach (var piece in puzzlePieces)
        {
            if (!piece.IsCorrectlyPlaced(otherPiece: new PecaClicavel(), positionCurrent: piece.indiceBase))
                return false;
        }
        return true;
    }
    public static bool OneSeletionPiece(bool estaSelecionada)
    {
        foreach (var piece in FindObjectsOfType<PecaClicavel>())
        {
            //if (piece.estaSelecionada)
                return true;
        }
        return false;
    }

}


