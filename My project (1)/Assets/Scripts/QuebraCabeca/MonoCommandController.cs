using UnityEngine;
using UnityEngine.UI;

public class MonoCommandController : MonoBehaviour
{
    public Transform player;
    public Button cancelReplay;
    public Button undoButton;
    
    private CommandController commandController;
    
    private void Awake()
    {
        commandController = new CommandController(player, this, cancelReplay, undoButton);
    }
    public void ExecuteCommand(ICommand command)
    {
        commandController.ExecuteCommand(command);
    }
    public void Undo()
    {
        commandController.Undo();
    }
    public void StartReplay()
    {
        commandController.StartReplay();
    }
    public void CancelReplay()
    {
        commandController.CancelReplay();
    }
    private void OnePieceSeletion(bool estaSelecionado)
    {
        commandController.UpdateUndoButtonState(estaSelecionado);
    }
}