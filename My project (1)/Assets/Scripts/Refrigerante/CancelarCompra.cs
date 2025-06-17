using UnityEngine;

public class CancelarCompra : MonoBehaviour
{
    public int moedas;
    
    public void RetirarMoeda()
    {
        moedas--;
        //AtualizarMoedas(moedas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
