[System.Serializable]
public sealed class Shield : Armor, IItem
{
    public Item GetItem()
    {
        return this;
    }
}
