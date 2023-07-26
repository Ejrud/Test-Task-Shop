using UnityEngine;
using Zenject;

public class ShopService : MonoBehaviour, IInitializable
{
    [SerializeField] private View _viewPrefab;
    [Inject] private DataInteraction _dataInteraction;
    [Inject] private CanvasSwitcherService _canvasSwitcherService;
    private View _view;

    public void Initialize()
    {
        _view = Instantiate(_viewPrefab);
        _canvasSwitcherService.AddCanvas(_view.canvasType, _view.gameObject);
        _dataInteraction.OnItemDataChanged += UpdateList;
        UpdateList();
    }

    private void UpdateList()
    {
        _view.UpdateList(_dataInteraction.GetLockedItems());
        for (int i = 0; i < _view.frames.Length; i++)
        {
            ShopItemFrame item = (ShopItemFrame)_view.frames[i];
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
    }

    private void ErrorMessage(string message)
    {
        Debug.Log(message);
    }

    private void OnDestroy()
    {
        if (_canvasSwitcherService)
            _canvasSwitcherService.RemoveCanvas(_view.canvasType);
        
        if (_dataInteraction)
            _dataInteraction.OnItemDataChanged -= UpdateList;
        
        for (int i = 0; i < _view.frames.Length; i++)
        {
            if (!(ShopItemFrame)_view.frames[i])
                return;
            
            ShopItemFrame item = (ShopItemFrame)_view.frames[i];
            item.OnSelect -= PrepareBuyItem;
        }
    }
}
