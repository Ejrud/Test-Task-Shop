using UnityEngine;
using UnityEngine.UI;

public class ShopItemFrame : ItemFrame
{
    [SerializeField] private Button _buyButton;
    
    public override void Init(Item item)
    {
        _item = item;
        _name.text = item.name;
        _icon.texture = item.icon;
    }

    public override void SetActive(bool active)
    {
        
    }
}
