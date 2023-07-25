using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CurrencyViewController : MonoBehaviour
{
    [SerializeField] private CurrencyViewType[] _currencyViewType;
    private Dictionary<CurrencyType, CurrencyViewType> _currencyDictionary;
    private DataInteraction _dataInteraction;
    
    [Inject]
    public void Construct(DataInteraction dataInteraction)
    {
        _dataInteraction = dataInteraction;
        CreateCurrecyDictionary();
        InitializeCurrencyContent();
        _dataInteraction.OnCurrancyChanged += UpdateCurrency;
    }

    private void CreateCurrecyDictionary()
    {
        _currencyDictionary = new Dictionary<CurrencyType, CurrencyViewType>();
        foreach (var unit in _currencyViewType)
        {
            _currencyDictionary.Add(unit.currencyType, unit);
        }
    }

    private void UpdateCurrency(CurrencyType type, int value)
    {
        if (_currencyDictionary.TryGetValue(type, out CurrencyViewType viewType))
        {
            viewType.UpdateValue(value.ToString());
        }
    }

    private void InitializeCurrencyContent()
    {
        foreach (var unit in _currencyViewType)
        {
            Currency currency = _dataInteraction.GetCurrencyByType(unit.currencyType);
            unit.UpdateValue(currency.value.ToString());
        }
    }

    private void OnDestroy()
    {
        if (_dataInteraction)
            _dataInteraction.OnCurrancyChanged -= UpdateCurrency;
    }
}
