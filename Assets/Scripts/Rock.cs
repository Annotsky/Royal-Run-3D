using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionParticleSystem;
    [SerializeField] private AudioSource _boulderSmashAudio;
    [SerializeField] private float _shakeModifer = 10f;
    [SerializeField] private float _collisionCooldown = 1f;

    private CinemachineImpulseSource _cinemachineImpulse;
    private float _collisionTimer = 1f;

    private void Awake()
    {
        _cinemachineImpulse = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        _collisionTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_collisionTimer < _collisionCooldown) return;

        FireImpulse();
        CollisionFX(other);
        _collisionTimer = 0;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * _shakeModifer;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        _cinemachineImpulse.GenerateImpulse(shakeIntensity);
    }

    private void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        _collisionParticleSystem.transform.position = contactPoint.point;
        _collisionParticleSystem.Play();
        _boulderSmashAudio.Play();
    }
}