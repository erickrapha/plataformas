using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnPlayerPisando;

    public static void PlayerPisando()
    {
        OnPlayerPisando?.Invoke();
    }
}
