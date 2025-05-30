using UnityEngine;

public class PecaClicavel : MonoBehaviour
{
    private static PecaClicavel pecaSelecionada;
    
    /*private void OnMouseDown()
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
        
        void TrocarPosicao(PecaClicavel outraPeca)
        {
            Vector3 tempPos = transform.position;
            transform.position = outraPeca.transform.position;
            outraPeca.transform.position = tempPos;
        }
        void Destacar(bool ativar)
        {
            GetComponent<Renderer>().material.color = ativar == true ? Color.yellow : Color.white;
        }
        
    }*/
    
}
