using UnityEngine;

public class Peca : MonoBehaviour
{
    public static Peca selecionada1;
    public static Peca selecionada2;
    
    private void OnMouseDown()
    {
        /*if (selecionada1 == null)
        {
            selecionada1 = this;
            Destacar(true);
        }
        else if (selecionada2 == null && this != null)
        {
            selecionada2 = this;
            Destacar(true);
            Trocar();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
