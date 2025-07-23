using UnityEngine;

public class PecaClicavel : MonoBehaviour
{
    private static PecaClicavel _pecaSelecionada;

    public int indiceBase;
    public Vector2 locationPiece;
    public Vector2 correctionLocation;
    public bool estaSelecionada;

    public bool IsCorrectlyPlaced(int positionCurrent)
    {
        return indiceBase == positionCurrent;  
    }
    public void Destacar(bool ativar)
    {
        GetComponent<SpriteRenderer>().material.color = ativar ? Color.yellow : Color.white;
    }
}

