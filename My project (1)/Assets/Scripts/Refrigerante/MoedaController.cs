using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoedaController : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public TextMeshProUGUI moedasText;
    public TextMeshProUGUI avisoTMP;
    public GameObject refrigerante;
    
    [Header("Botôes de controle")] 
    public Button botaoCancelar;
    public Button botaoComprar;
    public Button botaoInserir;

    private int moedas = 0;
    
    void Start()
    {
        AtualizarUI();
        if (avisoTMP != null) avisoTMP.gameObject.SetActive(false);
        if (refrigerante != null) refrigerante.SetActive(false);
    }
    public void ColetarMoeda()
    {
        LimparAviso();
        moedas++;
        AtualizarEstado();
        AdicionarRefrigerante();
        Debug.Log("Moeda Coletada. Total:" + moedas);
    }
    public void UsarMoeda()
    {
        LimparAviso();
        if (moedas > 0)
        {
            moedas--;
            AtualizarEstado();
            Debug.Log("Moeda usada. Restam" + moedas);
        }
        else
        {
            MostrarAviso("Sem moedas para usar!");
        }
    }
    public void RetirarMoeda()
    {
        LimparAviso();
        if (moedas > 0)
        {
            moedas--;
            AtualizarEstado();
            Debug.Log("Moeda retirada. Restam" + moedas);
        }
        else
        {
            MostrarAviso("Nenhuma moeda para retirar!");
        }
    }
    public void AdicionarRefrigerante()
    {
        LimparAviso();
        if (moedas > 0)
        {   
            if (moedas > 0)
            {
                UsarMoeda();
                if (refrigerante != null) refrigerante.SetActive(true);
                MostrarAviso("Você pegou" + refrigerante.name);
            }
        }
        else
        {
            MostrarAviso("Insira uma moeda antes!");
        }
    }
    private void AtualizarEstado()
    {
        if (animator != null)
            animator.SetBool("TemMoeda", moedas > 0);
        
        AtualizarUI();
    }
    private void AtualizarUI()
    {
        if (moedasText != null)
            moedasText.text = "Moedas:" + moedas;

        if (moedas == 0)
        {
            TravarComprar(false);
            TravarCancelar(false);
            TravarInserir(true);
        }
    }
    private void MostrarAviso(string mensagem)
    {
        if (avisoTMP != null)
        {
            avisoTMP.gameObject.SetActive(true);
            avisoTMP.text = mensagem;
        }
    }
    public void LimparAviso()
    {
        if (avisoTMP != null)
        {
            avisoTMP.gameObject.SetActive(false);
        }
    }
    private void TravarComprar(bool travar)
    {
        if (botaoComprar != null)
        {
            botaoComprar.interactable = !travar;
        }
    }
    private void TravarCancelar(bool travar)
    {
        if (botaoCancelar != null)
        {
            botaoCancelar.interactable = !travar;
        }
    }
    private void TravarInserir(bool travar)
    {
        if (botaoInserir != null)
        {
            botaoInserir.interactable = !travar;
        }
    }
}
