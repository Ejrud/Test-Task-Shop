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
            item.OnSelect += BuyItem;
        }
    }

    private void BuyItem(Item item, CurrencyType currencyType)
    {
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
        BuyItem(item);
    }

    private void BuyItem(Item item)
    {
        
    }

    private bool IsEnoughtCurrecy(int currecyStorage, int cost, CurrencyType type)
    {
        bool isEnough = currecyStorage > cost;
        if (!isEnough) ErrorMessage(type);
        return isEnough;
    }

    private void ErrorMessage(CurrencyType type)
    {
        Debug.Log($"Not enough {type} to buy");
    }
}
