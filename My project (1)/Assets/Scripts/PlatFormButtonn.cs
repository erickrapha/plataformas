using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlatFormButton : MonoBehaviour
{
    
    public void Pisar()
    {
        EventManager.PlayerPisando();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(message: "O Player está pisando no PlatFormButton");
            EventManager.PlayerPisando();
        }
    }

}
