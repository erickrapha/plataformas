using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerObserverManager : MonoBehaviour
{
    //Criar o canal
    public static event Action<int> OnMoedasChanged;
    
    //Criar o "Postar vídeos"
    public static void ChangedMoedas(int moedas)
    {
        //Olha se tem inscritos e envia as notificações
        OnMoedasChanged?.Invoke(moedas);
    }
}
