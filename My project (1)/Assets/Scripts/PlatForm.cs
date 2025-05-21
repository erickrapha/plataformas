using UnityEngine;

public class PlatForm : MonoBehaviour
{
    public void Pisar()
    {
        EventManager.PlayerPisando();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //EventManager();
        }
    }
}
