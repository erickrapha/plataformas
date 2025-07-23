using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

public class CommandController
{
    private Transform player;
    private int currentCommandIndex = 0;
    private List<ICommand> commandHistory = new();
    private bool isReplaying = false;
    private Coroutine replayCoroutine;
    
    private Button cancelReplay;
    private Button undoButton;
    private MonoBehaviour coroutineRunner;

    public bool IsReplaying => isReplaying;

    public CommandController(Transform player, MonoBehaviour coroutineRunner, Button cancelReplay, Button undoButton)
    {
        this.player = player;
        this.coroutineRunner = coroutineRunner;
        this.cancelReplay = cancelReplay;
        this.undoButton = undoButton;
        
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);
        
        UpdateUndoButtonState(false);
    }
    public void ExecuteCommand(ICommand command)
    {
        if (isReplaying) return;
        if (currentCommandIndex < commandHistory.Count)
            commandHistory.RemoveRange(currentCommandIndex, commandHistory.Count - currentCommandIndex);
        
        command.Execute();
        commandHistory.Add(command);
        currentCommandIndex++;
        UpdateUndoButtonState(false);
    }
    public void Undo()
    {
        if (currentCommandIndex == 0 || isReplaying) return;
        
        currentCommandIndex--;
        commandHistory[currentCommandIndex].Undo();
        UpdateUndoButtonState(false);
        //Desfez o ato
    }
    /*public void StartReplay()
    {
        if (commandHistory.Count == 0 || isReplaying) return;
        
        replayCoroutine = StartCoroutine(Replay());
    }
    private IEnumerator Replay()
    {
        isReplaying = true;
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(true);

        player.position = Vector2.zero;
        currentCommandIndex = 0;
        
        foreach (var command in commandHistory)
        {
            if (!isReplaying) yield break;
            
            command.Execute();
            yield return new WaitForSeconds(0.5f);
        }
        isReplaying = false;
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);
        
        PuzzleManager manager = FindFirstObjectByType<PuzzleManager>();
        if (manager != null)
            manager.CheckPuzzleCompletion();
    }
    public void CancelReplay()
    {
        if (!isReplaying) return;
        
        isReplaying = false;
        if (replayCoroutine != null)
            StopCoroutine(replayCoroutine);
        
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);
        
        Debug.Log("Replay cancelado");
    }*/

    public void UpdateUndoButtonState(bool OnePieceSelection)
    {
        if (undoButton != null)
            undoButton.interactable = !OnePieceSelection && currentCommandIndex > 0 && !isReplaying;
    }
}
