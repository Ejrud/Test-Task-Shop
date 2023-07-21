using System.Collections.Generic;
using UnityEngine;

public class VaultController : MonoBehaviour
{
    public List<Item> items => _itemsList;
    [SerializeField] private GameObject[] _itemObjects;
    
    private Dictionary<int, Item> _itemDictionary = new Dictionary<int, Item>();
    private List<Item> _itemsList = new List<Item>();

    public void Initialize()
    {
        _itemsList = GetItemsFromObjects(_itemObjects);
        foreach (var item in _itemsList)
        {
            _itemDictionary.Add(item.id, item);
        }
    }

    public Item GetItemById(int id)
    {
        Item item = null;
        
        if (_itemDictionary.TryGetValue(id, out item))
            return item;

        return item;
    }

    private List<Item> GetItemsFromObjects(GameObject[] itemObjects)
    {
        List<Item> items = new List<Item>();

        for (int i = 0; i < itemObjects.Length; i++)
        {
            if (!itemObjects[i].TryGetComponent<IItem>(out IItem item))
                continue;
            
            items.Add(item.GetItem());
        }

        return items;
    }
}
