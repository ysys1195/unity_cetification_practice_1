using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static int Coin;

    void Start()
    {
        Coin = 0;
    }

    public static bool IsCoinToRecover()
    {
        if (Coin != 10) return false;

        Coin = 0;
        return true;
    }
}