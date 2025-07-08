using UnityEngine;

public class MoedaController : MonoBehaviour
{
    public Animator animator;
    
    public void ColetarMoeda()
    {
        animator.SetBool("TemMoeda", true);
        Debug.Log("Moeda Coletada");
    }
    public void UsarMoeda()
    {
        animator.SetBool("TemMoeda", true);
        Debug.Log("Usando Moeda");
    }
}
