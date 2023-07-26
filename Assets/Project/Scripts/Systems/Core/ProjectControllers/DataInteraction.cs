using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class DataInteraction : MonoBehaviour
{
    public event Action<CurrencyType, int> OnCurrancyChanged;
    public event Action OnItemDataChanged;
    
    private VaultController _vault;
    private DataService _dataService;
    private Dictionary<CurrencyType, Currency> _currencies;

    [Inject]
    public void Construct(DataService dataService, VaultController vault)
    {
        _dataService = dataService;
        _vault = vault;
    }

    public void Initialize()
    {
        CreateCurrecyDictionary();
    }
    
    public Currency GetCurrencyByType(CurrencyType type)
    {
        if (_currencies.TryGetValue(type, out Currency currecy))
            return currecy;
        
        throw new NotImplementedException();
    }

    public void RemoveCurrecy(CurrencyType type, int value)
    {
        Currency currency = GetCurrencyByType(type);
        currency.value -= value;
        OnCurrancyChanged?.Invoke(type, currency.value);
    }
    
    public bool IsEnoughtCurrecy(CurrencyType type, int value)
    {
        Currency currency = GetCurrencyByType(type);
        return currency.value > value;
    }

    public List<Item> GetUserItems()
    {
        return _dataService.data.items;
    }
    
    // Ужасная логика сортировки, времени на реализацию адекватного решения не было
    public List<Item> GetLockedItems()
    {
        List<Item> lockedItems = new List<Item>();

        foreach (var vaultItem in _vault.items)
        {
            bool isContains = false;
            foreach (var userItem in _dataService.data.items)
            {
                if (userItem.id == vaultItem.id)
                    isContains = true;
            }
            
            if (!isContains)
                lockedItems.Add(vaultItem);
        }

        return lockedItems;
    }

    public void AddItem(Item item)
    {
        _dataService.data.items.Add(item);
        item.SetBlock(false);
        OnItemDataChanged?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        _dataService.data.items.Remove(item);
        OnItemDataChanged?.Invoke();
    }
    
    public bool IsContainsInInventory(int id)
    {
        for (int i = 0; i < _dataService.data.items.Count; i++)
        {
            if (_dataService.data.items[i].id == id)
                return true;
        }

        return false;
    }

    private void CreateCurrecyDictionary()
    {
        _currencies = new Dictionary<CurrencyType, Currency>();
        foreach (var currecy in _dataService.data.currency)
        {
            _currencies.Add(currecy.type, currecy);
        }
    }
}
