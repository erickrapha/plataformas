using TMPro;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class Inserir : MonoBehaviour
{
    public int moedas = 0;
    private Text moedasText;
    
    public TextMeshProUGUI avisoTMP;
    public GameObject refrigerante;
    
    public void AdicionarMoeda()
    {
        moedas++;
        AtualizarMoedas();
    }
    public void AtualizarMoedas()
    {
        moedasText.text = "Moedas:" + moedas;
    }
    public void RetirarMoeda()
    {
        moedas--;
        AtualizarMoedas();
    }
    public void AdicionarRefrigerante()
    {
        avisoTMP.gameObject.SetActive(true);
        refrigerante.SetActive(true);
        avisoTMP.text = refrigerante.name;
    }
}
