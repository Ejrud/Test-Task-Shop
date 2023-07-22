using System;
using UnityEngine;

[Serializable]
public sealed class Scrool : Item, ITimed
{
    public bool isRunning { get; set; }
    
    public string activeTime
    {
        get
        {
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            return String.Format("{0} h. {1} m. {2} s.", time.Hours, time.Minutes, time.Seconds);
        }
    }

    // 1f = 1 sec
    [SerializeField] private float _activeTime;
    private float currentTime;


    public void UpdateTime()
    {
        currentTime = Mathf.Clamp(currentTime - Time.deltaTime, 0, _activeTime);

        if (currentTime == 0)
        {
            SetBlock(true);
        }

    }

    public void SetTime(bool activate)
    {
        if (isRunning)
        {
            // Sync
            return;
        }

        switch (activate)
        {
            case true:
                currentTime = _activeTime;
                break;
            
            case false:
                currentTime = 0;
                break;
        }
    }
    
    public override void SetBlock(bool block)
    {
        base.SetBlock(block);
        SetTime(!block);
    }
}
