using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ItemFrame : MonoBehaviour
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected TMP_Text _name;
    protected Item _item;

    public virtual void Initialize(Item item, Sprite icon)
    {
        _item = item;
        _name.text = item.name;
        _icon.sprite = icon;
    }

    public abstract void SetBlock(bool active);
}
