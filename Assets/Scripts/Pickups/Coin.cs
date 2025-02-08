using UnityEngine;
using UnityEngine.Events;

public class Coin : Pickup
{
    [SerializeField] private int _coinAmount = 100;

    public static event UnityAction<int> OnCoinPicked;

    protected override void OnPickup()
    {
        OnCoinPicked?.Invoke(_coinAmount);
    }
}