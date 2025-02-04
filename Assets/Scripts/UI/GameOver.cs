using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private PlayerController _playerController;
    
    private Timer _timer;
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void Update()
    {
        if (IsGameOver)
        {
            return;
        }
        if (_timer.TimeLeft <= 0)
        {
            ActivateGameOver();
        }
    }

    private void ActivateGameOver()
    {
        IsGameOver = true;
        _playerController.enabled = false;
        _gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
