using UnityEngine;
using System;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PecaClicavel> puzzlePieces;
    public Transform gridPanel;
    
    public bool isPuzzleCompleted = false;
    public PecaClicavel _pecaSelecionada;
    
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
            if (!piece.IsCorrectlyPlaced(puzzlePieces.IndexOf(piece)))
                return false;
        }
        return true;
    }
    private bool OneSeletionPiece()
    {
        foreach (var piece in FindObjectsOfType<PecaClicavel>())
        {
            if (piece.estaSelecionada)
                return true;
        }
        return false;
    }
    public void OnMouseDown(PecaClicavel pieceActually)
    {
        if (_pecaSelecionada == null)
        {
            _pecaSelecionada = pieceActually;
            _pecaSelecionada.Destacar(true);
        }
        else if (_pecaSelecionada == pieceActually)
        {
            _pecaSelecionada.Destacar(false);
            _pecaSelecionada = null;
        }
        else
        {
            TrocarPosicao(pieceActually);
            _pecaSelecionada.Destacar(false);
            _pecaSelecionada = null;
        }
    }
    private void TrocarPosicao(PecaClicavel pieceActually)
    {
        int k = puzzlePieces.IndexOf(_pecaSelecionada);
        int n = puzzlePieces.IndexOf(pieceActually);
        
        PecaClicavel temp = puzzlePieces[k];
        puzzlePieces[k] = puzzlePieces[n];
        puzzlePieces[n] = temp;
        puzzlePieces[n].transform.SetSiblingIndex(n);
        puzzlePieces[k].transform.SetSiblingIndex(k);
    }

}


