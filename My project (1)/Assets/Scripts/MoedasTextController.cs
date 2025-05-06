using System;
using TMPro;
using UnityEngine;

public class MoedasTextController : MonoBehaviour
{
    private TMP_Text moedasText;
    
    private void OnValidate()
    {
        moedasText = GetComponent<TMP_Text>();
    }
    /*private void OnEnable()
    {
        PlayerObserverManager.OnMoedasChanged += AtualizaMoedas;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnMoedasChanged -= AtualizaMoedas;
    }

    private void AtualizaMoedas(int valor)
    {
        MoedasTextController.text = "Moedas: " + valor.ToString();
    }*/
}
