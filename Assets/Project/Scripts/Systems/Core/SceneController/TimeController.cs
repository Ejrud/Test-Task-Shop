using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TimeController : MonoBehaviour
{
    private List<ITimed> timedItems = new List<ITimed>();
    private DataInteraction _data;
    
    [Inject]
    public void Construct(DataInteraction data)
    {
        _data = data;
    }

    public void UpdateItems(List<Item> items)
    {
        timedItems = new List<ITimed>();
        
        foreach (var item in items)
        {
            if (item is ITimed)
                timedItems.Add((ITimed)item);
        }
    }

    private void Update()
    {
        // float delta = Time.deltaTime;
        // foreach (var item in timedItems)
        // {
        //     item.UpdateTime(delta);
        //     
        //     if (item.isDeleted)
        //         continue;
        //     
        //     if (item.GetSeconds <= 0)
        //     {
        //         _data.RemoveItem((Item)item);
        //         item.isDeleted = true;
        //     }
        // }
    }
}
