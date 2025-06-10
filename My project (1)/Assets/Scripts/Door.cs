using System;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnPlayerPisando += ReagirAoPisao;
    }
    private void OnDisable()
    {
        EventManager.OnPlayerPisando -= ReagirAoPisao;
    }
    void ReagirAoPisao()
    {
        Debug.Log("O Player pisou! Recebi o Evento");
        Destroy(gameObject);
    }
}
