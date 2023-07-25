using TMPro;
using UnityEngine;

public class CurrencyViewType : MonoBehaviour
{
    public CurrencyType currencyType => _currencyType;
    [SerializeField] private CurrencyType _currencyType;
    [SerializeField] private TMP_Text _value;
    
    public void UpdateValue(string value)
    {
        _value.text = value;
    }
}
