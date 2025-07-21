using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CommandController1", menuName = "Scriptable Objects/CommandController1")]
public class S0CommandController : ScriptableObject
{/*
    [SerializeField] public Transform player;
    public int currentCommandIndex = 0;
    public Button cancelReplay;
    public Button undoButton;
    
    [SerializeField] private PlayerCommand playerCommand;
    private List<ICommand> commandHistory = new List<ICommand>();
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
    }
    void ExecuteCommand(ICommand command)
    {
        if (currentCommandIndex < commandHistory.Count)
            commandHistory.RemoveRange(currentCommandIndex, commandHistory.Count - currentCommandIndex);
        
        command.Execute();
        commandHistory.Add(command);
        currentCommandIndex++;
    }
    public void Undo()
    {
        if (currentCommandIndex == 0) return;
        
        currentCommandIndex--;
        commandHistory[currentCommandIndex].Undo();
        //Desfez o ato
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
    }*/
}
