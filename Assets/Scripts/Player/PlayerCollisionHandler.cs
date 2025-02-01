using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _collisionCooldown = 1f;
    [SerializeField] private float _adjustMoveSpeedAmount = -2f;
    
    private static readonly int Hit = Animator.StringToHash("Hit");
    
    private float _cooldownTimer;

    public static event UnityAction<float> OnHit;

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_cooldownTimer < _collisionCooldown) return;

        OnHit?.Invoke(_adjustMoveSpeedAmount);
        _animator.SetTrigger(Hit);
        _cooldownTimer = 0f;
    }
}
