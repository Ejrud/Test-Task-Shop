using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Разделил логику загрузки данных и логику взаимодействия
// данных на разные классы по принципу единой ответственности
public class DataService : MonoBehaviour
{
    public UserData data;
    public VaultController vault => _vault;
    
    [Header("Data for the first run")] 
    [SerializeField] private DefaultData _defaultData;
    [SerializeField] private VaultController _vault;
    
    [Header("Settings")] 
    [SerializeField] private string _fileName = "userData";
    [SerializeField] private string _filePath;
    
    private BinarySerialization _binarySerialization;
    
    public void Initialize()
    {
        _binarySerialization = new BinarySerialization();
        TryLoadData();
    }

    public void SaveData()
    {
        _binarySerialization.Serialize(_filePath, data);
    }

    private void TryLoadData()
    {
        _filePath = Path.Combine(Application.persistentDataPath, _fileName);

        if (File.Exists(_filePath))
        {
            data = _binarySerialization.Deserialize<UserData>(_filePath);
        }
        else
        {
            LoadDefaultData();
        }
    }

    private void LoadDefaultData()
    {
        data = new UserData();

        foreach (var unit in _defaultData.source.currency)
        {
            data.currency.Add(new Currency(unit.type, unit.value));
        }
        
        data.items = new List<Item>();
        _vault.ResetItems();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
