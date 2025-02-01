using UnityEngine;
using UnityEngine.Events;

public class Apple : Pickup
{
    [SerializeField] private float _adjustMoveSpeedAmount = 2f;
    
    public static event UnityAction<float> OnApplePicked;

    protected override void OnPickup()
    {
        OnApplePicked?.Invoke(_adjustMoveSpeedAmount);
    }
}
