using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TimeService : MonoBehaviour, IInitializable
{
    private List<ITimed> timedItems = new List<ITimed>();
    private DataInteraction _dataInteraction;
    
    [Inject]
    public void Construct(DataInteraction data)
    {
        _dataInteraction = data;
    }

    public void Initialize()
    {
        UpdateItems();
        _dataInteraction.OnItemDataChanged += UpdateItems;
    }

    public void UpdateItems()
    {
        timedItems = new List<ITimed>();
        List<Item> userItems = _dataInteraction.GetUserItems();
        
        foreach (var item in userItems)
        {
            if (item is ITimed)
                timedItems.Add((ITimed)item);
        }
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        
        foreach (var item in timedItems)
        {
            if (item.remainingTime > 0)
            {
                item.UpdateTime(delta);
                continue;
            }

            if (!item.idBlocked)
            {
                item.idBlocked = true;
                _dataInteraction.RemoveItem((Item)item);
            }
        }
    }
    
    private void OnDestroy()
    {
        if (_dataInteraction)
            _dataInteraction.OnItemDataChanged -= UpdateItems;
    }
}
