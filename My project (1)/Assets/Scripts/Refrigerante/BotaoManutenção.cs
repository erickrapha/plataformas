using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BotaoManutenção : MonoBehaviour
{
    [Header("Referências")]
    public Animator animator;
    public TMP_Text textoManutenção;
    public MoedaController avisos;

    [Header("Botôes de controle")] 
    public Button buttonCancel;
    public Button buttonComprar;
    
    private bool emManutencao;

    void Start()
    {
        emManutencao = false;
        animator.SetBool("EmManutenção", false);
        
        if (textoManutenção != null)
        {
            textoManutenção.gameObject.SetActive(false);
        }
        TravarBotao(false);
    }
    public void IniciarManutencao()
    {
        emManutencao = true;
        animator.SetBool("EmManutenção", true);
        
        if (textoManutenção != null)
        {
            textoManutenção.gameObject.SetActive(true);
        }
        if (avisos != null)
        {
            avisos.LimparAviso();
        }
        TravarBotao(true);
    }
    public void TerminarManutencao()
    {
        emManutencao = false;
        animator.SetBool("EmManutenção", false);
        
        if (textoManutenção != null)
        {
            textoManutenção.gameObject.SetActive(false);
        }
        TravarBotao(false);
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
    private void TravarBotao(bool travar)
    {
        if (buttonCancel != null)
        {
            buttonCancel.interactable = !travar;
        }
        if (buttonComprar != null)
        {
            buttonComprar.interactable = !travar;
        }
    }
}