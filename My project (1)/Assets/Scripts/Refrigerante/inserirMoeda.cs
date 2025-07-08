using UnityEngine;
using UnityEngine.UI;

public class InserirMoeda : MonoBehaviour
{
    public int moedas = 0;
    private Text moedasText;
    
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
}
