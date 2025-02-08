using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    private const string PlayerString = "Player";

    public static event UnityAction OnPlayerEnters;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerString))
            OnPlayerEnters?.Invoke();
    }
}