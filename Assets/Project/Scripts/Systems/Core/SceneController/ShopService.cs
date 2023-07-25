using UnityEngine;
using Zenject;
using System;

public class ShopService : MonoBehaviour, IInitializable
{
    public event Action OnItemPurchased;
    
    [SerializeField] private ShopViewer view;
    private VaultController _vault;
    private DataInteraction _dataInteraction;
    
    [Inject]
    public void Construct(VaultController vaultController, DataInteraction dataInteraction)
    {
        _vault = vaultController;
        _dataInteraction = dataInteraction;
    }

    public void Initialize()
    {
        UpdateList();
    }

    private void UpdateList()
    {
        view.UpdateList(_vault.items);
        for (int i = 0; i < view.frames.Length; i++)
        {
            ShopItemFrame item = (ShopItemFrame)view.frames[i];
            item.OnSelect += PrepareBuyItem;
        }
    }

    private void PrepareBuyItem(Item item, CurrencyType currencyType)
    {
        if (_dataInteraction.IsContainsInInventory(item.id))
        {
            ErrorMessage("This item has already been purchased");
            return;
        }

        int cost = item.GetCostByCurrecy(currencyType);
        if (!_dataInteraction.IsEnoughtCurrecy(currencyType, cost))
        {
            ErrorMessage($"Not enough {currencyType} to buy");
            return;
        }

        Debug.Log($"Buy {item.name}");
        BuyItem(item, currencyType);
    }

    private void BuyItem(Item item, CurrencyType type)
    {
        _dataInteraction.RemoveCurrecy(type, item.GetCostByCurrecy(type));
        _dataInteraction.AddItem(item);
        OnItemPurchased?.Invoke();
    }

    private bool IsEnoughtCurrecy(int currecyStorage, int cost, CurrencyType type)
    {
        bool isEnough = currecyStorage > cost;
        if (!isEnough) ErrorMessage("Not enough funds " + type);
        return isEnough;
    }

    private void ErrorMessage(string message)
    {
        Debug.Log(message);
    }
}
