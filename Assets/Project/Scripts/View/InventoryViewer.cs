using System.Collections.Generic;
using UnityEngine;

public class InventoryViewer : View
{
    [SerializeField] private TimedItemFrame _timedItemPrefab;
    private List<TimedItemFrame> _timedFrames = new List<TimedItemFrame>();
    private void Update()
    {
        foreach (var timeItem in _timedFrames)
        {
            timeItem.UpdateText();
        }
    }

    public override void CreateNewList(List<Item> items)
    {
        int count = 0;
        
        _frames = new ItemFrame[items.Count];
        _timedFrames = new List<TimedItemFrame>();
        
        foreach (Item item in items)
        {
            if (item is ITimed)
            {
                _frames[count] = Instantiate(_timedItemPrefab);
                _timedFrames.Add((TimedItemFrame)_frames[count]);
            }
            else
            {
                _frames[count] = Instantiate(_itemFramePrefab);
            }

            _frames[count].transform.SetParent(_parent);
            _frames[count].transform.localScale = Vector3.one;
            
            Sprite icon = _imageDictionary.GetSpriteByName(item.imageName);
            _frames[count].Initialize(item, icon);
            count++;
        }
    }
}
