using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class View : MonoBehaviour
{
    public ItemFrame[] frames => _frames;
    public CanvasType canvasType => _canvasType;
    
    [SerializeField] protected CanvasType _canvasType;
    [SerializeField] protected Transform _parent;
    [SerializeField] protected ImageDictionary _imageDictionary;
    [SerializeField] protected ItemFrame _itemFramePrefab;
    protected ItemFrame[] _frames = new ItemFrame[0];

    public virtual void UpdateList(List<Item> items)
    {
        ClearItemList();
        CreateNewList(items);
    }

    public virtual void CreateNewList(List<Item> items)
    {
        int count = 0;
        _frames = new ItemFrame[items.Count];
        foreach (Item item in items)
        {
            _frames[count] = Instantiate(_itemFramePrefab);
            _frames[count].transform.SetParent(_parent);
            _frames[count].transform.localScale = Vector3.one;
            
            Sprite icon = _imageDictionary.GetSpriteByName(item.imageName);
            _frames[count].Initialize(item, icon);
            count++;
        }
    }
    
    // Не лучший способ обновления ячеек, в идеале вместо удаления обновлять ячейки
    private void ClearItemList()
    {
        foreach (var frame in _frames)
        {
            Destroy(frame.gameObject);
        }
    }
}
