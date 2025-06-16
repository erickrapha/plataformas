using System;
using static UnityEditor.Undo;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class GameController 
{
    /*private PlayerCommand _player = new PlayerCommand();
    private List<ICommand> commandHistory = new List<ICommand>();
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();

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
            commandHiostory.Add(command);
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
        Debug.Log();
    }*/
}
