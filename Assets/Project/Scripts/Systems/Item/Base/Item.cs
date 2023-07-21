using UnityEngine;

[System.Serializable]
public abstract class Item : MonoBehaviour
{
    public string name => _name;
    public string description => _description;
    public float cost => _cost;
    public int id => _id;
    public bool isBlocked => _isBlocked;
    public Texture2D icon => _icon.texture;

    [SerializeField] protected string _name;
    [SerializeField] protected string _description;
    [SerializeField] protected float _cost;
    
    [SerializeField] protected int _id;
    [SerializeField] protected bool _isBlocked;
    [SerializeField] protected Sprite _icon;

    public void Construct(BaseData baseData)
    {
        _name = baseData.name;
        _description = baseData.description;
        _cost = baseData.cost;
        _id = baseData.id;
        _isBlocked = baseData.isBlocked;
        _icon = baseData.icon;
    }

    public void SetBlock(bool block)
    {
        _isBlocked = block;
    }
}
