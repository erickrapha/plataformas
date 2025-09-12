using UnityEngine;
using TMPro;

public class BotaoManutenção : MonoBehaviour
{
    public Animator animator;
    public TMP_Text textoManutenção;
    
    private bool emManutencao;

    void Start()
    {
        emManutencao = false;
        animator.SetBool("EmManutencao", false);
        if (textoManutenção != null)
        {
            textoManutenção.gameObject.SetActive(false);
        }
    }
    public void IniciarManutencao()
    {
        emManutencao = true;
        animator.SetBool("EmManutencao", true);
        if (textoManutenção != null)
        {
            textoManutenção.gameObject.SetActive(true);
        }
    }
    public void TerminarManutencao()
    {
        emManutencao = false;
        animator.SetBool("EmManutencao", false);
        if (textoManutenção != null)
        {
            textoManutenção.gameObject.SetActive(false);
        }
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