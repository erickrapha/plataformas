using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoedaController : MonoBehaviour
{
    [Header("Referências")]
    public Animator animator;
    public TextMeshProUGUI moedasText;
    public TextMeshProUGUI avisoVazio;
    public TextMeshProUGUI avisoOk;
    public GameObject refrigerantePrefab;
    public Transform slotRefrigerante;
     
    [Header("Botões de controle")] 
    public Button botaoCancelar;
    public Button botaoComprar;
    public Button botaoInserir;

    private int moedas = 0;
    private int estoque = 3;
    private bool emManutencao = false;
    
    void Start()
    {
        AtualizarUI();
        if (avisoVazio != null) avisoVazio.gameObject.SetActive(false);
        if (avisoOk != null) avisoOk.gameObject.SetActive(false);
    }
    public void EntrarManutencao()
    {
        emManutencao = true;
        animator.SetTrigger("EmManutenção");
        TravarBotoes(true, true, false);
        MostrarEstoque();
    }
    public void SairManutencao()
    {
        emManutencao = false;
        if (estoque <= 0)
        {
            animator.SetTrigger("SemRefrigerante");
        }
        else if (moedas > 1)
        {
            animator.SetTrigger("ComMoeda");
        }
        else 
        {
            animator.SetTrigger("SemMoeda");
        }
        AtualizarUI();
    }
    public void Inserir()
    {
        if (emManutencao)
        {
            estoque++;
            MostrarEstoque();
        }
        else if (estoque > 0)
        {
            moedas++;
            animator.SetTrigger("ComMoeda");
            avisoOk.gameObject.SetActive(true);
            TravarBotoes(true, false, false);
        }
    }
    public void Cancelar()
    {
        if (!emManutencao & moedas > 0)
        {
            moedas--;
            if (moedas == 0)
            {
                animator.SetTrigger("SemMoeda");
                avisoOk.gameObject.SetActive(true);
                TravarBotoes(false, true, true);
            }
            AtualizarUI();
        }
    }
    public void Comprar()
    {
        if (!emManutencao && moedas > 0 && estoque > 0)
        {
            moedas--;
            estoque--;
            animator.SetTrigger("Venda");
            SoltarRefrigerante();
            Invoke(nameof(VerificarPosCompra), 2f);
        }
    }
    private void VerificarPosCompra()
    {
        if (estoque <= 0)
        {
            animator.SetTrigger("SemRefrigerante");
            avisoVazio.gameObject.SetActive(true);
            TravarBotoes(true, true, true);
        }
        else if (moedas > 0)
        {
            animator.SetTrigger("ComMoeda");
            avisoOk.gameObject.SetActive(true);
            TravarBotoes(true, false, false);
        }
        else
        {
            animator.SetTrigger("SemMoeda");
            avisoOk.gameObject.SetActive(false);
            TravarBotoes(false, true, true);
        }
        AtualizarUI();
    }
    private void MostrarEstoque()
    {
        foreach (Transform child in slotRefrigerante)
            Destroy(child.gameObject);
        for (int i = 0; i < estoque; i++)
        {
            Instantiate(refrigerantePrefab, slotRefrigerante);
        }
    }
    private void SoltarRefrigerante()
    {
        if (refrigerantePrefab != null)
        {   
            GameObject refri = Instantiate(refrigerantePrefab);
            refri.transform.position = slotRefrigerante.position + Vector3.down * 2;
        }
    }
    private void AtualizarUI()
    {
        moedasText.text = "Moedas:" + moedas;
    }
    private void TravarBotoes(bool travarInserir, bool travarCancelar, bool travarComprar)
    {
        if (botaoComprar != null) botaoComprar.interactable = !travarComprar;
        if (botaoCancelar != null) botaoCancelar.interactable = !travarCancelar;
        if (botaoInserir != null) botaoInserir.interactable = !travarInserir;
    }
}
