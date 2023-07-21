[System.Serializable]
public sealed class Sword : Weapon, IItem
{
    public Item GetItem()
    {
        return this;
    }
}
