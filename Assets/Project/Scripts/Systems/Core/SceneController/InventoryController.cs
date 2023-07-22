using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private ShopController _shop;
    [SerializeField] private View view;
    [SerializeField] private TimeController _timeController;
    private VaultController _vault;
    private DataController _dataController;
    
    [Inject]
    public void Construct(VaultController vaultController, DataController dataController)
    {
        _vault = vaultController;
        _dataController = dataController;
        UpdateList();

        _shop.OnItemPurchased += UpdateList;
    }
    
    private void UpdateList()
    {
        List<Item> items = GetUnlockedItems(_vault.itemDictionary, _dataController.data.items);
        view.UpdateList(items);
        _timeController.UpdateItems(items);
    }

    private List<Item> GetUnlockedItems(Dictionary<int, Item> dictionary, List<Item> userItems)
    {
        List<Item> items = new List<Item>(); 
        
        foreach (var item in userItems)
        {
            dictionary.Remove(item.id);
            dictionary.Add(item.id, item);
        }

        foreach (var item in dictionary)
        {
            items.Add(item.Value);
        }

        return items;
    }
}
