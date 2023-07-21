using UnityEngine;
using Zenject;

public class ShopController : MonoBehaviour
{
    [SerializeField] private ItemViewer _itemViewer;
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
        _itemViewer.UpdateList(_vault.items);
        for (int i = 0; i < _itemViewer.frames.Length; i++)
        {
            ShopItemFrame item = (ShopItemFrame)_itemViewer.frames[i];
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

        switch (currencyType)
        {
            case CurrencyType.Silver:
                if (!IsEnoughtCurrecy(_dataController.data.currency.silver, item.cost, CurrencyType.Silver))
                    return;
                
                break;
            
            case CurrencyType.Gold:
                if (!IsEnoughtCurrecy(_dataController.data.currency.gold, item.cost, CurrencyType.Gold))
                    return;
                
                break;
                
            case CurrencyType.Platinum:
                if (!IsEnoughtCurrecy(_dataController.data.currency.platinum, item.cost, CurrencyType.Platinum))
                    return;
                
                break;
        }

        Debug.Log($"Buy {item.name}");
        BuyItem(item, currencyType);
    }

    private void BuyItem(Item item, CurrencyType type)
    {
        _dataController.RemoveCurrecy(type, item.cost);
        _dataController.AddItem(item);
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
