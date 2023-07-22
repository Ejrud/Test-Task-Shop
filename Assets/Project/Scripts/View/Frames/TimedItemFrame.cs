using TMPro;
using UnityEngine;

public class TimedItemFrame : InventoryItemFrame
{
    [SerializeField] private TMP_Text _time;

    public void UpdateText(string timeText)
    {
        _time.text = timeText;
    }
}
