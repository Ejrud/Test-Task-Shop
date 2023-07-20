using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    [SerializeField] private Sprite _defaultSprite;
    public List<Item> items = new List<Item>();

    public void Init()
    {
        items = CreateDebugItems();
    }

    private List<Item> CreateDebugItems()
    {
        List<Item> debugItems = new List<Item>();
        
        for (int i = 0; i < 50; i++)
        {
            debugItems.Add(new Sword(DebugItem(i), 124f));
        }

        return debugItems;
    }

    private BaseItemData DebugItem(int i)
    {
        BaseItemData data = new BaseItemData();
        data.isBlocked = true;
        data.name = "Default sword";
        data.description = "Default description";
        data.cost = i + 29;
        data.icon = _defaultSprite;
        
        return data;
    }
}
