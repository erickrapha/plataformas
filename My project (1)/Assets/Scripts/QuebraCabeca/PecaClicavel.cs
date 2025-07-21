using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using static UnityEngine.Color;

public class PecaClicavel : MonoBehaviour
{
    private static PecaClicavel _pecaSelecionada;

    public int indiceBase;
    public Vector2 locationPiece;
    public Vector2 correctionLocation;
    public bool estaSelecionada;
    //[SerializeField]public Button btn;

    public bool IsCorrectlyPlaced(int positionCurrent)
    {
        return indiceBase == positionCurrent;  
        //return locationPiece == correctionLocation;
        //return Vector2.Distance(transform.position, locationPiece) < 0.1f;
    }
    public void OnMouseDown()
    {
        if (_pecaSelecionada == null)
        {
            _pecaSelecionada = this;
            Destacar(true);
        }
        else if (_pecaSelecionada == this)
        {
            Destacar(false);
            _pecaSelecionada = null;
        }
        else
        {
            TrocarPosicao(_pecaSelecionada);
            _pecaSelecionada.Destacar(false);
            _pecaSelecionada = null;
        }
        //btn.enabled = true;
    }
    private void TrocarPosicao(PecaClicavel otherPiece)
    {
        Vector2 tempPos = transform.position;
        transform.position = otherPiece.transform.position;
        otherPiece.transform.position = tempPos;
    }
    
    public void Destacar(bool ativar)
    {
        GetComponent<SpriteRenderer>().material.color = ativar ? Color.yellow : Color.white;
    }
}

