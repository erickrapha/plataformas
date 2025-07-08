using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlatFormButton : MonoBehaviour
{
    
    public void Pisar()
    {
        EventManager.PlayerPisando();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("O Player está pisando no PlatFormButton");
            EventManager.PlayerPisando();
        }
    }

}
