using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    private const string _playerString = "Player";

    public static event UnityAction OnPlayerEnters;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerString))
            OnPlayerEnters?.Invoke();
    }
}