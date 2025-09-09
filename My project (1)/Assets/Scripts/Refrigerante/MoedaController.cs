using UnityEngine;

public class MoedaController : MonoBehaviour
{
    public Animator animator;

    private int moedas = 0;
    
    public void ColetarMoeda()
    {
        moedas++;
        animator.SetBool("TemMoeda", moedas > 0);
        Debug.Log("Moeda Coletada. Total:" + moedas);
    }
    public void UsarMoeda()
    {
        if (moedas > 0)
        {
            moedas--;
            animator.SetBool("TemMoeda", moedas > 0);
            Debug.Log("Moeda usada. Restam" + moedas);
        }
        else
        {
            Debug.Log("Sem moedas para usar!");
        }
    }
}
