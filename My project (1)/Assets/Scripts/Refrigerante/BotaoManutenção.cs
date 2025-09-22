using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BotaoManutenção : MonoBehaviour
{
    [Header("Referências")] 
    public MoedaController maquina;
    //public Animator animator;
    public TMP_Text textoManutenção;
    /*public MoedaController okAviso;
    public MoedaController vazioAviso;*/
    public Button buttonCancel;
    public Button buttonComprar;
    
    private bool emManutencao = false;

    void Start()
    {
        /*emManutencao = false;
        animator.SetBool("EmManutenção", false);
        
        if (textoManutenção != null)
        {*/
            textoManutenção.gameObject.SetActive(false);
        /*}
        TravarBotao(false);*/
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
    private void IniciarManutencao()
    {
        emManutencao = true;
        textoManutenção.gameObject.SetActive(true);
        //maquina.EntrarManutencao();
        TravarBotao(true);
    }
    public void TerminarManutencao()
    {
        emManutencao = false;
        textoManutenção.gameObject.SetActive(false);
        //maquina.SairManutencao();
        TravarBotao(false);
    }
    private void TravarBotao(bool travar)
    {
        if (buttonCancel != null)
            buttonCancel.interactable = !travar;
        
        if (buttonComprar != null)
            buttonComprar.interactable = !travar;
    }
}