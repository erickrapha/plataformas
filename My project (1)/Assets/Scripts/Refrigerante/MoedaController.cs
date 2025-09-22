using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoedaController : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public TextMeshProUGUI moedasText;
    public TextMeshProUGUI avisoVazio;
    public TextMeshProUGUI avisoOk;
    public GameObject refrigerante;
     
    [Header("Botôes de controle")] 
    public Button botaoCancelar;
    public Button botaoComprar;
    public Button botaoInserir;

    private int moedas = 0;
    
    void Start()
    {
        AtualizarUI();
        if (avisoVazio != null) avisoVazio.gameObject.SetActive(false);
        if (avisoOk != null) avisoOk.gameObject.SetActive(false);
        if (refrigerante != null) refrigerante.SetActive(false);
    }
    public void ColetarMoeda()
    {
        moedas++;
        AtualizarEstado();
        AdicionarRefrigerante();
        if (avisoVazio != null) avisoVazio.gameObject.SetActive(false);
        if (avisoOk != null) avisoOk.gameObject.SetActive(true);
    }
    public void UsarMoeda()
    {
        if (moedas > 0)
        {
            moedas--;
            AtualizarEstado();
            if (avisoVazio != null) avisoVazio.gameObject.SetActive(false);
            if (avisoOk != null) avisoOk.gameObject.SetActive(true);
        }
        else
        {
            if (avisoOk != null) avisoOk.gameObject.SetActive(false);
            if (avisoVazio != null) avisoVazio.gameObject.SetActive(true);
        }
    }
    public void RetirarMoeda()
    {
        
        if (moedas > 0)
        {
            moedas--;
            AtualizarEstado();
            if (avisoVazio != null) avisoVazio.gameObject.SetActive(false);
            if (avisoOk != null) avisoOk.gameObject.SetActive(true);
        }
        else
        {
            if (avisoOk != null) avisoOk.gameObject.SetActive(false);
            if (avisoVazio != null) avisoVazio.gameObject.SetActive(true);
        }
    }
    public void AdicionarRefrigerante()
    {
        if (moedas > 0)
        {   
            if (moedas > 0)
            {
                UsarMoeda();
                if (refrigerante != null) refrigerante.SetActive(true);
                if (avisoVazio != null) avisoVazio.gameObject.SetActive(false);
                if (avisoOk != null) avisoOk.gameObject.SetActive(true);
            }
        }
        else
        {
            if (avisoOk != null) avisoOk.gameObject.SetActive(false);
            if (avisoVazio != null) avisoVazio.gameObject.SetActive(true);
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
            TravarComprar(true);
            TravarCancelar(true);
            TravarInserir(false);
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
