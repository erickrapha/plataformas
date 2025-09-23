using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BotaoManutenção : MonoBehaviour
{
    [Header("Referências")] 
    public MoedaController maquina;
    public TMP_Text textoManutenção;
    public Button buttonCancel;
    public Button buttonComprar;
    
    private bool emManutencao = false;

    void Start()
    {
        textoManutenção.gameObject.SetActive(false);
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
        maquina.EntrarManutencao();
        TravarBotoes(true);
    }
    public void TerminarManutencao()
    {
        emManutencao = false;
        textoManutenção.gameObject.SetActive(false);
        maquina.SairManutencao();
        TravarBotoes(false);
    }
    private void TravarBotoes(bool travar)
    {
        if (buttonCancel != null) buttonCancel.interactable = !travar;
        
        if (buttonComprar != null) buttonComprar.interactable = !travar;
    }
}