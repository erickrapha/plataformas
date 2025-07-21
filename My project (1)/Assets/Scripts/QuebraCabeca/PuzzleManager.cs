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
    public static bool OneSeletionPiece()
    {
        foreach (var piece in FindObjectsOfType<PecaClicavel>())
        {
            if (piece.estaSelecionada)
                return true;
        }
        return false;
    }
    
    public void OnMouseDown(PecaClicavel pecaAtual)
    {
        if (_pecaSelecionada == null)
        {
            _pecaSelecionada = pecaAtual;
            _pecaSelecionada.Destacar(true);
        }
        else if (_pecaSelecionada == pecaAtual)
        {
            _pecaSelecionada.Destacar(false);
            _pecaSelecionada = null;
        }
        else
        {
            TrocarPosicao(pecaAtual);
            _pecaSelecionada.Destacar(false);
            _pecaSelecionada = null;
        }
        //btn.enabled = true;
    }

    private void TrocarPosicao(PecaClicavel pecaAtual)
    {
        int k = puzzlePieces.IndexOf(_pecaSelecionada);
        int n = puzzlePieces.IndexOf(pecaAtual);
        
        PecaClicavel temp = puzzlePieces[k];
        puzzlePieces[k] = puzzlePieces[n];
        puzzlePieces[n] = temp;
        puzzlePieces[n].transform.SetSiblingIndex(n);
        puzzlePieces[k].transform.SetSiblingIndex(k);
        
    }
}


