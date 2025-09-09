using TMPro;
using UnityEngine;

public class Inserir : MonoBehaviour
{
    public int moedas = 0;
    private TextMeshProUGUI moedasText;
    public TextMeshProUGUI avisoTMP;
    public GameObject refrigerante;

    void Start()
    {
        AtualizarMoedas();
        avisoTMP.gameObject.SetActive(false);
        refrigerante.SetActive(false);
    }
    public void AdicionarMoeda()
    {
        moedas++;
        AtualizarMoedas();
    }
    public void RetirarMoeda()
    {
        if (moedas > 0)
        {
            moedas--;
            AtualizarMoedas();
        }
    }
    public void AtualizarMoedas()
    {
        moedasText.text = "Moedas:" + moedas;
    }
    public void AdicionarRefrigerante()
    {
        if (moedas > 0)
        {
            avisoTMP.gameObject.SetActive(true);
            refrigerante.SetActive(true);
            avisoTMP.text = "Você pegou" + refrigerante.name;
            moedas--;
            AtualizarMoedas();
        }
        else
        {
            avisoTMP.gameObject.SetActive(true);
            avisoTMP.text = "Insira uma moeda primeiro!";
        }
    }
}
