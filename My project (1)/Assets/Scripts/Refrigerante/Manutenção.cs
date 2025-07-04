using UnityEngine;

public class EstadoManutenção : StateMachineBehaviour
{
    public Animator animator;
    
    private bool emManutencao = false;

    void Start()
    {
        animator.SetBool("EmManutencao", false);
    }
    public void IniciarManutencao()
    {
        emManutencao = true;
        animator.SetBool("EmManutencao", emManutencao);
    }
    public void TerminarManutencao()
    {
        emManutencao = false;
        animator.SetBool("EmManutencao", emManutencao);
    }
}
