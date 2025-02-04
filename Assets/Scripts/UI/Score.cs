using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

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
        _score += amount;
        _scoreText.text = _score.ToString();
    }
}
