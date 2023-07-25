using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private ShopController _shop;
    [SerializeField] private View view;
    [SerializeField] private TimeController _timeController;
    private VaultController _vault;
    private DataService _dataService;
    
    [Inject]
    public void Construct(VaultController vaultController, DataService dataService)
    {
        _vault = vaultController;
        _dataService = dataService;
        UpdateList();

        _shop.OnItemPurchased += UpdateList;
    }
    
    private void UpdateList()
    {
        List<Item> items = GetUnlockedItems(_vault.itemDictionary);
        
        // foreach (var item in items)
        //     item.OnItemBloked += (blockedItem) => { _dataController.RemoveItem(blockedItem); };
        
        view.UpdateList(items);
        _timeController.UpdateItems(items);
    }

    private List<Item> GetUnlockedItems(Dictionary<int, Item> dictionary)
    {
        List<Item> items = new List<Item>(); 
        
        foreach (var item in dictionary)
            items.Add(item.Value);

        return items;
    }
}
