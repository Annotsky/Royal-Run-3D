using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _startTime = 5f;
    
    private GameOver _gameOver;
    
    public float TimeLeft { get; private set; }

    private void Awake()
    {
        _gameOver = GetComponent<GameOver>();
    }

    private void Start()
    {
        TimeLeft = _startTime; 
    }

    private void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (_gameOver.IsGameOver) return;
        TimeLeft -= Time.deltaTime;
        _timerText.text = TimeLeft.ToString("F1");
    }
}
