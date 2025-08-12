using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommandController
{
    public bool IsReplaying => isReplaying;
    
    private int currentCommandIndex = 0;
    private List<ICommand> commandHistory = new();
    private bool isReplaying = false;
    private Coroutine replayCoroutine;
    private Button cancelReplay;
    private Button undoButton;
    private MonoBehaviour coroutineRunner;

    public CommandController(MonoBehaviour coroutineRunner, Button cancelReplay, Button undoButton)
    {
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
    public void StartReplay()
    {
        if (commandHistory.Count == 0 || isReplaying) return;
        
        if (replayCoroutine != null)
        {
            coroutineRunner.StopCoroutine(replayCoroutine);
        }
        replayCoroutine = coroutineRunner.StartCoroutine(ReplayFromStart());
    }
    public void CancelReplay()
    {
        if (!isReplaying) return;
        
        isReplaying = false;
        
        if (replayCoroutine != null)
            coroutineRunner.StopCoroutine(replayCoroutine);
        
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);
        
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
            
            yield return new WaitForSeconds(1);
            Debug.Log("StartReplay");
        }
        isReplaying = false;
        
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);
        
        PuzzleManager manager = UnityEngine.Object.FindFirstObjectByType<PuzzleManager>();
        manager?.CheckPuzzleCompletion();
    }
    void UpdateUndoButtonState(bool onePieceSelection)
    {
        if (undoButton != null)
            undoButton.interactable = !onePieceSelection && currentCommandIndex > 0 && !isReplaying;
    }
}
