using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PecaClicavel> puzzlePieces;
    [SerializeField] private GameObject victoryScreen;
    private int currentCommandIndex = 0;
    private List<ICommand> commandHistory = new();
    private bool isReplaying = false;
    private Coroutine replayCoroutineInstance;
    
    public Transform gridPanel;
    public bool isPuzzleCompleted = false;
    public PecaClicavel _pecaSelecionada;
    public Button cancelReplay;
    public Button undoButton;
    public Button replayButton;
    
    private void Awake()
    {
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);
        
        if (replayButton != null)
            replayButton.gameObject.SetActive(false);

        UpdateUndoButtonState(false);
    }
    void Start()
    {
        QuebraCabeca.Embaralhar(puzzlePieces, gridPanel);
    }
    void Update()
    {
        if (!isPuzzleCompleted && CheckPuzzleCompletion())
        {
            isPuzzleCompleted = true;
            Debug.Log("O Puzzle está completo");
            UIManager.instance.ShowVictoryScreen();
            
            if (replayButton != null)
                replayButton.gameObject.SetActive(true);
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
            ExecuteCommand(new TrocarPosicao(puzzlePieces, _pecaSelecionada, pieceActually));
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
    private void ExecuteCommand(ICommand command)
    {
        if (isReplaying) return;
        
        if (currentCommandIndex < commandHistory.Count)
            commandHistory.RemoveRange(currentCommandIndex, commandHistory.Count - currentCommandIndex);
        
        command.Execute();
        commandHistory.Add(command);
        currentCommandIndex++;
        UpdateUndoButtonState(false);
    }
    public void Desfazer()
    {
        if (currentCommandIndex == 0 || isReplaying) return;
        
        currentCommandIndex--;
        commandHistory[currentCommandIndex].Undo();
        UpdateUndoButtonState(false);
        
        if (undoButton != null)
            undoButton.gameObject.SetActive(true);
        //Desfez o ato
    }
    public void StartReplay()
    {
        if (commandHistory.Count == 0 || isReplaying) return;
        
        if (replayCoroutineInstance != null)
            StopCoroutine(replayCoroutineInstance);
        
        replayCoroutineInstance = StartCoroutine(ReplayFromStart());
    }
    public void CancelReplay()
    {
        if (!isReplaying) return;
        
        isReplaying = false;
        
        if (replayCoroutineInstance != null)
            StopCoroutine(replayCoroutineInstance);
        
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);

        if (victoryScreen != null)
        {
            Time.timeScale = 0f;
            victoryScreen.SetActive(true);
        }
        Debug.Log("Replay cancelado");
    }
    private IEnumerator ReplayFromStart()
    {
        isReplaying = true;
        
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(true);
        
        for (int i = currentCommandIndex - 1; i > 0; i--)
        {
            commandHistory[i].Undo();
        }
        currentCommandIndex = 0;
        
        foreach (var command in commandHistory)
        {
            if (!isReplaying) yield break;
            
            command.Execute();
            currentCommandIndex++;
            
            yield return new WaitForSeconds(5.0f);
        }
        isReplaying = false;
        
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);
        
        CheckPuzzleCompletion();
    }
    void UpdateUndoButtonState(bool onePieceSelection)
    {
        if (undoButton != null)
            undoButton.interactable = !onePieceSelection && currentCommandIndex > 0 && !isReplaying;
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
        StartReplay();
    }
}


