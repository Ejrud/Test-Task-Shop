using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemFrame : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    private Item _item;
    
    public void Init(Item item)
    {
        _item = item;
        _name.text = item.name;
        // _icon.sprite = item.icon;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
