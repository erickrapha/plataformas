using UnityEngine;

public class EstadoManutenção : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Iniciou a manutenção da máquina");
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Terminou a manutenção da máquina");
    }
    
}
