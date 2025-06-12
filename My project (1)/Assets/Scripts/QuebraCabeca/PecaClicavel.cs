using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using static UnityEngine.Color;

public class PecaClicavel : MonoBehaviour
{
    private static PecaClicavel pecaSelecionada;

    private void OnMouseDown()
    {
        if (pecaSelecionada == null)
        {
            pecaSelecionada = this;
            Destacar(true);
        }
        else if (pecaSelecionada == this)
        {
            Destacar(false);
            pecaSelecionada = null;
        }
        else
        {
            TrocarPosicao(pecaSelecionada);
            pecaSelecionada.Destacar(false);
            pecaSelecionada = null;
        }
    }
    private void TrocarPosicao(PecaClicavel outraPeca)
    {
        Vector2 tempPos = transform.position;
        transform.position = outraPeca.transform.position;
        outraPeca.transform.position = tempPos;
    }
    private void Destacar(bool ativar)
    {
        GetComponent<SpriteRenderer>().material.color = ativar ? Color.yellow : Color.white;
    }
}

