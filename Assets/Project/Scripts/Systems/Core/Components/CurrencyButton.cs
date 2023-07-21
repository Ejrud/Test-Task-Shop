using TMPro;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class CurrencyButton
{
    public TMP_Text text => _text;
    public Button button => _button;
    public CurrencyType currencyType => _currencyType;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private CurrencyType _currencyType;

    public void SetButtonText(string text)
    {
        _text.text = text;
    }
}
