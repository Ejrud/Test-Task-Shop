using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ItemFrame : MonoBehaviour
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected TMP_Text _name;
    protected Item _item;
    
    public abstract void Initialize(Item item, Sprite icon);
    public abstract void SetActive(bool active);
}
