using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private PlayerController _playerController;

    public bool IsGameOver { get; private set; }

    private void OnEnable()
    {
        Timer.OnTimeExpired += ActivateGameOver;
    }

    private void OnDisable()
    {
        Timer.OnTimeExpired -= ActivateGameOver;
    }

    private void ActivateGameOver()
    {
        IsGameOver = true;
        _playerController.enabled = false;
        _gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}