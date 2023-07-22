using UnityEngine;

public class InventoryItemFrame : ItemFrame
{
    [SerializeField] protected GameObject _blockImage;    
    
    public override void Initialize(Item item, Sprite icon)
    {
        _item = item;
        _name.text = item.name;
        _icon.sprite = icon;
        
        SetBlock(item.isBlocked);
    }

    public override void SetBlock(bool active)
    {
        _blockImage.SetActive(active);
    }
}
