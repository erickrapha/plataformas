using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

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
            list[n] = list[k];
            list[k] = temp;
            list[n].transform.SetSiblingIndex(n);
            list[k].transform.SetSiblingIndex(k);
        }
    }
}

