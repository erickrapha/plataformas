using UnityEngine;

public class SemMoeda : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("TemMoeda", false);
        Debug.Log("Iniciou o estado Sem Moeda");
    }
}
