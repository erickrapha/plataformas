using System;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnPlayerPisando += ReagirAPisada;
    }
    private void OnDisable()
    {
        EventManager.OnPlayerPisando -= ReagirAPisada;
    }

    private void ReagirAPisada()
    {
        Debug.Log("O Player pisou! Recebi o Evento");
    }
}
