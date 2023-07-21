[System.Serializable]
public sealed class HeadArmor : Armor, IItem
{
    public Item GetItem()
    {
        return this;
    }
}
