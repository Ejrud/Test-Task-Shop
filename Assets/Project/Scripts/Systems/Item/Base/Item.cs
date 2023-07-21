using UnityEngine;

[System.Serializable]
public abstract class Item
{
    public string name => _name;
    public string imageName => _imageName;
    public string description => _description;
    public int cost => _cost;
    public int id => _id;
    public bool isBlocked => _isBlocked;

    [SerializeField] protected string _name;
    [SerializeField] protected string _imageName;
    [SerializeField] protected string _description;
    [SerializeField] protected int _cost;
    
    [SerializeField] protected int _id;
    [SerializeField] protected bool _isBlocked;

    public void Construct(BaseData baseData)
    {
        _name = baseData.name;
        _description = baseData.description;
        _cost = baseData.cost;
        _id = baseData.id;
        _isBlocked = baseData.isBlocked;
    }

    public void SetBlock(bool block)
    {
        _isBlocked = block;
    }
}
