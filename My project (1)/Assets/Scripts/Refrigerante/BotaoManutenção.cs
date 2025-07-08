using UnityEngine;

public class BotaoManutenção : MonoBehaviour
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
        animator.SetBool("EmManutencao", true);
    }
    public void TerminarManutencao()
    {
        emManutencao = false;
        animator.SetBool("EmManutencao", false);
    }
    public void AlternarManutencao()
    {
        if (emManutencao)
        {
            TerminarManutencao();
        }
        else
        {
            IniciarManutencao();
        }
    }
}