using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _startTime = 5f;
    [SerializeField] private float _timeToIncrease = 5;

    public static event UnityAction OnTimeExpired;

    private float _timeLeft;

    private void OnEnable()
    {
        Checkpoint.OnPlayerEnters += IncreaseTime;
    }

    private void OnDisable()
    {
        Checkpoint.OnPlayerEnters -= IncreaseTime;
    }

    private void Start()
    {
        _timeLeft = _startTime;
    }

    private void Update()
    {
        DecreaseTime();
        CheckForTimeExpired();
    }

    private void IncreaseTime()
    {
        _timeLeft += _timeToIncrease;
    }

    private void DecreaseTime()
    {
        _timeLeft -= Time.deltaTime;
        _timerText.text = Mathf.Max(_timeLeft, 0).ToString("F1");
    }

    private void CheckForTimeExpired()
    {
        if (_timeLeft <= 0)
        {
            OnTimeExpired?.Invoke();
        }
    }
}