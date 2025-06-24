using System;
using static UnityEditor.Undo;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UIElements;

public class GameController 
{
    public Transform player;
    public Button cancelReplay;
    
    private List<ICommand> commandHistory = new List<ICommand>();
    //private PlayerCommand _player = new PlayerCommand();
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();
    
    private Coroutine replayCoroutine;
    private bool isReplaying = false;

    void Start()
    {
        if (cancelReplayButton != null)
        {
            cancelReplayButton.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isReplaying) return;

        if (Input.GetKeyDown(KeyCode.W)) ExecuteCommand(new MoveUpCommand(player));
        if (Input.GetKeyDown(KeyCode.Z)) Undo();
        if (Input.GetKeyDown(KeyCode.Y)) Redo();
        if (Input.GetKeyDown(KeyCode.R)) StartReplay();
    }

    void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Add(command);
        undoStack.Push(command);
        redoStack.Clear();     
    }
    void Undo()
    {
        if (undoStack.Count == 0) return;
        var command = undoStack.Pop();
        command.Undo();
        redoStack.Push(command);
        //Desfez o ato
    }
    void Redo()
    {
        if (redoStack.Count == 0) return;
        var command = redoStack.Pop();
        command.Execute();
        undoStack.Push(command);
        //Refez o ato
    }
    void StartReplay()
    {
        if (undoStack.Count == 0 || isReplaying) return;
        replayCoroutine = StartCoroutine(Replay());
    }

    IEnumerator Replay()
    {
        isReplaying = true;
        if(cancelReplayButton )
    }
    /*static void Main()
    {
        var gameController = new GameController();
        Debug.Log("Use WASD para mover, R para replay, Y para refazer, Z para desfazer e Q para sair");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Q) break;
            if (key == ConsoleKey.R) gameController.Replay();
            else gameController.HandleInput(key);
        }
    }*/
}
