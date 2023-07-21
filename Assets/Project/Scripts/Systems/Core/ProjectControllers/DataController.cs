using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public UserData data => _data;
    
    [Header("Data for the first run")] 
    [SerializeField] private DefaultData _defaultData;
    
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

    private void TryLoadData()
    {
        _filePath = Path.Combine(Application.persistentDataPath, _fileName);

        if (File.Exists(_filePath))
        {
            _data = _binarySerialization.Deserialize<UserData>(_filePath);
        }
        else
        {
            _data = _defaultData.source;
        }
    }

    private void OnApplicationQuit()
    {
        _binarySerialization.Serialize(_filePath, _data);
    }
}
