using System;
using System.Text;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action OnTimerStart;
    public event Action OnTimerEnd;

    public int Value => (int)_timerValue;
    public string FormattedValue
    {
        get
        {
            return (((int)_timerValue / 24) + "Days  " + ((int)_timerValue % 24) + "Hours");
        } 
    }

    [Header("Settings")]
    [SerializeField]
    private int _timerDuration = 5;
    [SerializeField]
    private bool _isIncremental = true;

    private bool _timerStarted = false;
    private float _timerValue = 0;

    public void StartTimer()
    {
        if (_isIncremental)
            _timerValue = 0;
        else
            _timerValue = _timerDuration;

        _timerStarted = true;
        OnTimerStart?.Invoke();
    }

    private void Update()
    {
        if (!_timerStarted)
            return;

        if(_isIncremental)
        {
            _timerValue += Time.deltaTime;

            if(_timerValue >= _timerDuration)
                OnTimerEnd?.Invoke();
        }
        else
        {
            _timerValue -= Time.deltaTime;

            if (_timerValue < 0)
                OnTimerEnd?.Invoke();
        }
    }
}
