using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemFrame : ItemFrame
{
    public event Action<Item, CurrencyType> OnSelect;
    [SerializeField] private Button _buyButton;
    [SerializeField] private CurrencyType _currencyType;
    
    public override void Initialize(Item item)
    {
        _item = item;
        _name.text = item.name;
        _icon.texture = item.icon;
        
        _buyButton.onClick.AddListener(() =>
        {
            OnSelect?.Invoke(_item, _currencyType);
        });
    }

    public override void SetActive(bool active)
    {
        
    }
}
