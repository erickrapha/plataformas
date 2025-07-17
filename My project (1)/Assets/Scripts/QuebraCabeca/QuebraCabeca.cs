using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System;

public static class QuebraCabeca 
{
    private static Random _random = new Random();
    
    public static void Embaralhar(List<PecaClicavel> list, Transform grid)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            PecaClicavel temp = list[k];
            list[k] = list[n];
            list[n] = temp;
            list[n].transform.SetSiblingIndex(n);
            list[k].transform.SetSiblingIndex(k);
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].indiceBase == 1)
            {
                Debug.Log($"Peça {i} está no lugar certo.");
            }
        }
    }
}

