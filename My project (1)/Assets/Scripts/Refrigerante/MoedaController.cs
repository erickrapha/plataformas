using TMPro;
using UnityEngine;

public class MoedaController : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public TextMeshProUGUI moedasText;
    public TextMeshProUGUI avisoTMP;
    public GameObject refrigerante;

    private int moedas = 0;
    
    void Start()
    {
        AtualizarUI();
        if (avisoTMP != null) avisoTMP.gameObject.SetActive(false);
        if (refrigerante != null) refrigerante.SetActive(false);
    }
    public void ColetarMoeda()
    {
        moedas++;
        AtualizarEstado();
        Debug.Log("Moeda Coletada. Total:" + moedas);
    }
    public void UsarMoeda()
    {
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
    }
    private void MostrarAviso(string mensagem)
    {
        if (avisoTMP != null)
        {
            avisoTMP.gameObject.SetActive(true);
            avisoTMP.text = mensagem;
        }
    }

}
