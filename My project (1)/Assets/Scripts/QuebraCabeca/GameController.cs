using System;
using static UnityEditor.Undo;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UIElements;

public class GameController 
{
    /*public Transform player;
    public Button cancelReplay;
    
    private List<ICommand> commandHistory = new List<ICommand>();
    //private PlayerCommand _player = new PlayerCommand();
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();
    
    private Coroutine replayCoroutine;
    private bool isReplaying = false;

    private void Start()
    {
        if (cancelReplayButton != null)
        {
            cancelReplayButton.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        if (isReplaying) return;
        
        if(Input.GetKeyDown(KeyCode.W)) Exec
        {
            
        }
    }
    public void HandleInput(ConsoleKey key)
    {
        ICommand command = null;

        switch (key)
        {
            case ConsoleKey.W : command = new MoveUpCommand(_player); break;
            case ConsoleKey.S : command = new MoveDownCommand(_player); break;
            case ConsoleKey.A : command = new MoveLeftCommand(_player); break;
            case ConsoleKey.D : command = new MoveRightCommand(_player); break;
            case ConsoleKey.Z : Undo(); return;
            case ConsoleKey.Y : Redo(); return;
            case ConsoleKey.R : Replay(); return;
        }
        if (command != null)
        {
            command.Execute();
            commandHistory.Add(command);
            undoStack.Push(command);
            redoStack.Clear();            
        }
    }
    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            var command = undoStack.Pop();
            command.Undo();
            redoStack.Push(command);
            Debug.Log("Desfez o ato");
        }
    }
    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            var command = redoStack.Pop();
            command.Execute();
            undoStack.Push(command);
            Debug.Log("Refez o ato");
        }
    }
    public void Replay()
    {
        Debug.Log("Replaying");
        _player = new PlayerCommand();
        foreach (var cmd in commandHistory)
        {
            cmd.Execute();
            Thread.Sleep(500);
        }
    }
    static void Main()
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
