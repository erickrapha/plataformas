using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    private CommandController commandController;
    [SerializeField] private List<PecaClicavel> puzzlePieces;
    [SerializeField] private GameObject victoryScreen;
    
    public Transform gridPanel;
    public bool isPuzzleCompleted = false;
    public PecaClicavel _pecaSelecionada;
    public Button replayCoroutine;
    public Button cancelReplay;
    public Button undoButton;
    
    private void Awake()
    {
        commandController = new CommandController(this, cancelReplay, undoButton);
    }
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
            UIManager.instance.ShowVictoryScreen();
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
            commandController.ExecuteCommand(new TrocarPosicao(puzzlePieces, _pecaSelecionada, pieceActually));
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
    public void Desfazer()
    {
        commandController.Undo();
        if (undoButton != null)
        {
            undoButton.gameObject.SetActive(true);
        }
    }
    public void CancelarReplay()
    {
        commandController.CancelReplay();
        if (victoryScreen != null)
        {
            Time.timeScale = 0f;
            victoryScreen.SetActive(true);
        }
    }
    public void TheReplay()
    {
        if (victoryScreen != null)
            victoryScreen.SetActive(false);

        if (undoButton != null)
            undoButton.gameObject.SetActive(false);
        
        isPuzzleCompleted = false;

        if (_pecaSelecionada != null)
        {
            _pecaSelecionada.Destacar(false);
            _pecaSelecionada = null;
        }
        commandController.StartReplay();
    }
}


