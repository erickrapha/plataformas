using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class QuebraCabeca 
{
    private static Random _random = new Random();
    
    public static void Embaralhar(List<PecaClicavel> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            PecaClicavel temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }
}

