using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public UserData data => _data;
    
    [Header("Data for the first run")] 
    [SerializeField] private DefaultData _defaultData;
    [SerializeField] private VaultController _vault;
    
    [Header("Settings")] 
    [SerializeField] private string _fileName = "userData";
    [SerializeField] private string _filePath;
    [SerializeField] private UserData _data;
    
    private BinarySerialization _binarySerialization;
    
    public void Initialize()
    {
        _binarySerialization = new BinarySerialization();
        TryLoadData();
    }

    public void RemoveCurrecy(CurrencyType type, int value)
    {
        switch (type)
        {
            case CurrencyType.Silver:
                _data.currency.silver -= value;
                break;
            
            case CurrencyType.Gold:
                _data.currency.gold -= value;
                break;
            
            case CurrencyType.Platinum:
                _data.currency.platinum -= value;
                break;
        }
    }

    public void AddItem(Item item)
    {
        _data.items.Add(item);
        item.SetBlock(false);
    }

    public bool IsContainsInInventory(int id)
    {
        for (int i = 0; i < _data.items.Count; i++)
        {
            if (_data.items[i].id == id)
                return true;
        }

        return false;
    }

    public void SaveData()
    {
        _binarySerialization.Serialize(_filePath, _data);
    }

    private void TryLoadData()
    {
        _filePath = Path.Combine(Application.persistentDataPath, _fileName);

        if (File.Exists(_filePath))
        {
            _data = _binarySerialization.Deserialize<UserData>(_filePath);
            foreach (var itemData in _data.items)
            {
                Debug.Log(itemData.name);
            }
        }
        else
        {
            _data = _defaultData.source;
            _data.items = new List<Item>();
            _vault.ResetItems();
        }
    }
    

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
