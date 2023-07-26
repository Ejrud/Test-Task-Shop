using System;
using TMPro;
using UnityEngine;

public class TimedItemFrame : InventoryItemFrame
{
    [SerializeField] private TMP_Text _time;
    
    public override void Initialize(Item item, Sprite icon)
    {
        base.Initialize(item, icon);
        UpdateText();
    }
    
    public void UpdateText()
    {
        ITimed iTimed = (ITimed)_item;
        TimeSpan time = TimeSpan.FromSeconds(iTimed.remainingTime);
        _time.text = String.Format("{0}h {1}m {2}s", time.Hours, time.Minutes, time.Seconds);
    }
    
}
