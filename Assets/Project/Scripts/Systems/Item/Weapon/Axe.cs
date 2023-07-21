[System.Serializable]
public sealed class Axe : Weapon, IItem
{
    public Item GetItem()
    {
        return this;
    }
}
