using UnityEngine;

public class Venda : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Comprar", true);
        Debug.Log("Iniciou o estado SemMoeda");
    }
}
