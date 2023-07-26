using System.Collections.Generic;
using UnityEngine;

public class VaultController : MonoBehaviour
{
    public List<Item> items => _itemsList;
    public Dictionary<int, Item> itemDictionary => _itemDictionary;
    
    [SerializeField] private ItemDictionary _defaultDictionary;
    
    private Dictionary<int, Item> _itemDictionary = new Dictionary<int, Item>();
    private List<Item> _itemsList = new List<Item>();

    public void Initialize()
    {
        _itemsList = _defaultDictionary.GetItems();
        foreach (var item in _itemsList)
        {
            _itemDictionary.Add(item.id, item);
        }
    }

    public void ResetItems()
    {
        _itemsList = _defaultDictionary.GetItems();
        foreach (var item in _itemsList)
            item.SetBlock(true);
    }
}
