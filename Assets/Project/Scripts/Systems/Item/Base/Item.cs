using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public abstract class Item
{
    public event Action<Item> OnItemBloked;
    public string name => _name;
    public string imageName => _imageName;
    public string description => _description;
    public List<Currency> costByCurrencys => _costByCurrencys;
    public int id => _id;
    public bool isBlocked => _isBlocked;

    [SerializeField] protected string _name;
    [SerializeField] protected string _imageName;
    [SerializeField] protected string _description;
    [SerializeField] protected List<Currency> _costByCurrencys;
    
    [SerializeField] protected int _id;
    [SerializeField] protected bool _isBlocked;

    public int GetCostByCurrecy(CurrencyType type)
    {
        foreach (var unit in _costByCurrencys)
        {
            if (unit.CurrencyType == type)
                return unit.value;
        }

        throw new NotImplementedException();
    }

    public virtual void SetBlock(bool block)
    {
        _isBlocked = block;

        if (block)
        {
            OnItemBloked?.Invoke(this);
        }
    }
}
