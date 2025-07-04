using UnityEngine;

public class ComMoeda : StateMachineBehaviour
{
    public Animator animator;
    private bool temMoeda = false;

    public void ColetarMoeda()
    {
        temMoeda = true;
        animator.SetBool("TemMoeda", temMoeda);
    }
}
