using UnityEngine;
using System;

[Serializable]
public abstract class Item
{
    public event Action<Item> OnItemBloked;
    public string name => _name;
    public string imageName => _imageName;
    public string description => _description;
    public Currency costByCurrency => _costByCurrency;
    public int id => _id;
    public bool isBlocked => _isBlocked;

    [SerializeField] protected string _name;
    [SerializeField] protected string _imageName;
    [SerializeField] protected string _description;
    [SerializeField] protected Currency _costByCurrency;
    
    [SerializeField] protected int _id;
    [SerializeField] protected bool _isBlocked;

    public int GetCostByCurrecy(CurrencyType type)
    {
        int cost = 0;
        
        switch (type)
        {
            case CurrencyType.Silver:
                cost = _costByCurrency.silver;
                break;
                
            case CurrencyType.Gold:
                cost = _costByCurrency.gold;
                break;
            
            case CurrencyType.Platinum:
                cost = _costByCurrency.platinum;
                break;
        }

        return cost;
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
