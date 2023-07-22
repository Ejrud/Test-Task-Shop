using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private List<ITimed> timedItems = new List<ITimed>();

    public void UpdateItems(List<Item> items)
    {
        foreach (var item in items)
        {
            if (item is ITimed)
                timedItems.Add((ITimed)item);
        }
    }

    private void Update()
    {
        foreach (var item in timedItems)
        {
            item.UpdateTime();
        }
    }
}
