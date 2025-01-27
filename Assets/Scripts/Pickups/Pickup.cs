using UnityEngine;

public class Pickup : MonoBehaviour
{
    private const string PlayerString = "Player";
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerString))
        {
            Destroy(gameObject);
        }
    }
}
