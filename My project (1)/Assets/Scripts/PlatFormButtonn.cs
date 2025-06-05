using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlatFormButton : MonoBehaviour
{
    public BoxCollider2D collision;
    public GameObject gameObject;
    
    public void Pisar()
    {
        EventManager.PlayerPisando();
    }
    private bool OnDestroy()
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(message: "O Player está pisando no PlatFormButton");
            EventManager.PlayerPisando();
        }
        return true;
    }

}
