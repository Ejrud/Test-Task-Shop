using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ItemFrame : MonoBehaviour
{
    [SerializeField] protected RawImage _icon;
    [SerializeField] protected TMP_Text _name;
    protected Item _item;
    
    public abstract void Init(Item item);
    public abstract void SetActive(bool active);
}
