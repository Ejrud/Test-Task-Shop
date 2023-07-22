using UnityEngine;
using Zenject;
using System;

public class ShopController : MonoBehaviour
{
    public event Action OnItemPurchased;
    
    [SerializeField] private ShopViewer view;
    private VaultController _vault;
    private DataController _dataController;
    
    [Inject]
    public void Construct(VaultController vaultController, DataController dataController)
    {
        _vault = vaultController;
        _dataController = dataController;
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
        if (_dataController.IsContainsInInventory(item.id))
        {
            ErrorMessage("This item has already been purchased");
            return;
        }

        int cost = item.GetCostByCurrecy(currencyType);

        switch (currencyType)
        {
            case CurrencyType.Silver:
                if (!IsEnoughtCurrecy(_dataController.data.currency.silver, cost, CurrencyType.Silver))
                    return;
                
                break;
            
            case CurrencyType.Gold:
                if (!IsEnoughtCurrecy(_dataController.data.currency.gold, cost, CurrencyType.Gold))
                    return;
                
                break;
                
            case CurrencyType.Platinum:
                if (!IsEnoughtCurrecy(_dataController.data.currency.platinum, cost, CurrencyType.Platinum))
                    return;
                
                break;
        }

        Debug.Log($"Buy {item.name}");
        BuyItem(item, currencyType);
    }

    private void BuyItem(Item item, CurrencyType type)
    {
        _dataController.RemoveCurrecy(type, item.GetCostByCurrecy(type));
        _dataController.AddItem(item);
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
