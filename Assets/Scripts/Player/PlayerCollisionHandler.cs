using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _collisionCooldown = 1f;
    
    private static readonly int Hit = Animator.StringToHash("Hit");
    
    private float _cooldownTimer;

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!(_cooldownTimer > _collisionCooldown)) return;
        _animator.SetTrigger(Hit);
        _cooldownTimer = 0f;
    }
}
