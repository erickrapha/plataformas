using UnityEngine;

public class EstadoManutenção : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Iniciou o estado manutenção");
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Terminou a manutenção da máquina");
    }
}
