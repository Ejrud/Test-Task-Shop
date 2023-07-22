using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/ItemDictionary", fileName = "ItemDictionary")]
public class ItemDictionary : ScriptableObject
{
    [SerializeField] private List<Sword> _swords;
    [SerializeField] private List<Axe> _axes;
    [SerializeField] private List<Shield> _shields;
    [SerializeField] private List<HeadArmor> _headArmors;
    [SerializeField] private List<Scrool> _scrools;

    public List<Item> GetItems()
    {
        List <Item> items = new List<Item>();
        items.AddRange(_swords);
        items.AddRange(_axes);
        items.AddRange(_shields);
        items.AddRange(_headArmors);
        items.AddRange(_scrools);
        return items;
    }
}
