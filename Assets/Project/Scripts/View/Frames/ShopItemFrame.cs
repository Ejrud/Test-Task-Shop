using System;
using UnityEngine;

public class ShopItemFrame : ItemFrame
{
    public event Action<Item, CurrencyType> OnSelect;
    [SerializeField] private CurrencyButton[] _currencyButton;

    public override void Initialize(Item item, Sprite icon)
    {
        base.Initialize(item, icon);

        foreach (var unit in _currencyButton)
        {
            unit.SetButtonText($"Buy for {_item.GetCostByCurrecy(unit.currencyType)} {unit.currencyType}"); 
            unit.button.onClick.AddListener(() =>
            {
                OnSelect?.Invoke(_item, unit.currencyType);
            });
        }
    }

    public override void SetBlock(bool active)
    {
        
    }
}
