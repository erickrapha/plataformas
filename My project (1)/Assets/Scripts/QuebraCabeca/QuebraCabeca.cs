using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class QuebraCabeca 
{
    private static Random random = new Random();
    
    public static void Embaralhar<T>(this IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

