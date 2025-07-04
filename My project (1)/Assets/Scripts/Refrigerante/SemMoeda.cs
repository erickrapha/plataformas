using UnityEngine;

public class SemMoeda : StateMachineBehaviour
{
    public Animator animator;
    
    private bool temMoeda = false;
    
    public void UsarMoeda()
    {
        temMoeda = false;
        animator.SetBool("TemMoeda", temMoeda);
    }
    void Start()
    {
        animator.SetBool("TemMoeda", false);
    }
}
