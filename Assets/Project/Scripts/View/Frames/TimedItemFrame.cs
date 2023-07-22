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
        _time.text = iTimed.GetTime;

        if (iTimed.GetSeconds <= 0)
        {
            SetBlock(true);
        }
    }
    
}
