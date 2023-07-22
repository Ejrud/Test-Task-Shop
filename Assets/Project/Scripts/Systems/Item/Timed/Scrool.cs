using System;
using UnityEngine;

[Serializable]
public sealed class Scrool : Item, ITimed
{
    public bool isRunning { get; set; }
    public bool isDeleted { get; set; }
    
    [SerializeField] private float _activeTime;
    private float _currentTime;

    public void UpdateTime(float delta)
    {
        if (!isBlocked)
            _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            _currentTime = 0;
        }
    }

    public float GetSeconds
    {
        get
        {
            return _currentTime;
        }
    }

    public string GetTime {
        get
        {
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            return String.Format("{0}h {1}m {2}s", time.Hours, time.Minutes, time.Seconds);
        }
    }


    public void SetTime(bool activate)
    {
        switch (activate)
        {
            case true:
                isDeleted = false;
                _currentTime = _activeTime;
                break;
            
            case false:
                _currentTime = 0;
                break;
        }
    }

    public override void SetBlock(bool block)
    {
        base.SetBlock(block);
        SetTime(!block);
    }
}
