using System;
using UnityEngine;

public static class PlayerObserverMnager

{
    public static event Action<int> OnCoinCollected;

    public static void SetCoinCollected(int currentCoins)
    {
        OnCoinCollected?.Invoke(currentCoins);
    }
    
}
