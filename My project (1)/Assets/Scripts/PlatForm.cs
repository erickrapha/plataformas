using UnityEngine;

public class PlatForm : MonoBehaviour
{
    private Collider2D collision;
    
    public void Pisar()
    {
        EventManager.PlayerPisando();
    }
    public void OnDestroy()
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("O Player está pisando no PlatForm");
            EventManager.PlayerPisando();
        }
    }
}
