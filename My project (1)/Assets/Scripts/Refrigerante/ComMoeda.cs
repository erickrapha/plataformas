using UnityEngine;

public class ComMoeda : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("TemMoeda", false);
        Debug.Log("Iniciou o estado Com Moeda");
    }
}
