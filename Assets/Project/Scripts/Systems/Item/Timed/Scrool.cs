using System;
using UnityEngine;

[Serializable]
public sealed class Scrool : Item, ITimed
{
    public float remainingTime { get; set; }
    public bool idBlocked { get; set; }

    [SerializeField] private float _activeTime;


    public void UpdateTime(float delta)
    {
        if (!isBlocked)
            remainingTime -= delta;

        if (remainingTime <= 0)
        {
            remainingTime = 0;
        }
    }

    public void SetTime(bool activate)
    {
        switch (activate)
        {
            case true:
                idBlocked = false;
                remainingTime = _activeTime;
                break;
            
            case false:
                remainingTime = 0;
                break;
        }
    }

    public override void SetBlock(bool block)
    {
        base.SetBlock(block);
        SetTime(!block);
    }
}
