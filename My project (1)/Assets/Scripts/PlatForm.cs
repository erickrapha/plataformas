using UnityEngine;

public class PlatForm : MonoBehaviour
{
    public string message;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(message + "O Player está encima de mim");
        }
    }
}
