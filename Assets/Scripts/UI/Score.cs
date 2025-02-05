using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameOverHandler _gameOverHandler;

    private int _score;

    private void OnEnable()
    {
        Coin.OnCoinPicked += AddScore;
    }

    private void OnDisable()
    {
        Coin.OnCoinPicked -= AddScore;
    }

    private void AddScore(int amount)
    {
        if (_gameOverHandler.IsGameOver) return;
        _score += amount;
        _scoreText.text = _score.ToString();
    }
}