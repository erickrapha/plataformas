//using System;
//using static UnityEditor.Undo;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CommandController : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private PlayerCommand playerCommand;
    
    public Button cancelReplay;
    public Button undoButton;
    
    private List<ICommand> commandHistory = new List<ICommand>();
    /*private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();*/
    private int currentCommandIndex = 0;
    private Coroutine replayCoroutine;
    private bool isReplaying = false;

    void Start()
    {
        if (cancelReplay != null)
            cancelReplay.gameObject.SetActive(false);
    }
    void Update()
    {
        if (isReplaying) return;

        bool oneSeletionPiece = PuzzleManager.OneSeletionPiece();

        if (undoButton != null)
        {
            undoButton.interactable = !oneSeletionPiece && currentCommandIndex > 0;
        }
        if (oneSeletionPiece) return;
        
        if (Input.GetKeyDown(KeyCode.W)) ExecuteCommand(new MoveUpCommand(playerCommand));
        if (Input.GetKeyDown(KeyCode.Z)) Undo();
        if (Input.GetKeyDown(KeyCode.Y)) Redo();
        if (Input.GetKeyDown(KeyCode.R)) StartReplay();
    }
    void ExecuteCommand(ICommand command)
    {
        if (currentCommandIndex < commandHistory.Count)
        {
            commandHistory.RemoveRange(currentCommandIndex, commandHistory.Count - currentCommandIndex);
        }
        command.Execute();
        commandHistory.Add(command);
        currentCommandIndex++;
        /*undoStack.Push(command);
        redoStack.Clear();*/
    }
    public void Undo()
    {
        if (currentCommandIndex == 0) return;
        //var command = undoStack.Pop();
        currentCommandIndex--;
        commandHistory[currentCommandIndex].Undo();
        //redoStack.Push(command);
        //Desfez o ato
    }
    void Redo()
    {
        if (currentCommandIndex >= commandHistory.Count) return;
        //var command = redoStack.Pop();
        commandHistory[currentCommandIndex].Execute();
        currentCommandIndex++;
        //undoStack.Push(command);
        //Refez o ato
    }
    public void StartReplay()
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
    }
}