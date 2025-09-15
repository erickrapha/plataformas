using UnityEngine;
using TMPro;

public class BotaoManutenção : MonoBehaviour
{
    public Animator animator;
    public TMP_Text textoManutenção;
    public MoedaController avisos;
    
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
        avisos.LimparAviso();
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