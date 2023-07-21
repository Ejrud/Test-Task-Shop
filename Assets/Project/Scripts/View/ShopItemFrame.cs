using System;
using UnityEngine;

public class ShopItemFrame : ItemFrame
{
    public event Action<Item, CurrencyType> OnSelect;
    [SerializeField] private CurrencyButton[] _currencyButton;

    public override void Initialize(Item item, Sprite icon)
    {
        _item = item;
        _name.text = item.name;
        _icon.sprite = icon;

        foreach (var unit in _currencyButton)
        {
            unit.SetButtonText($"Buy for {unit.currencyType}"); 
            unit.button.onClick.AddListener(() =>
            {
                OnSelect?.Invoke(_item, unit.currencyType);
            });
        }
    }

    public override void SetActive(bool active)
    {
        
    }
}
