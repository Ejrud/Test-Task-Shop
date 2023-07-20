public class Sword : Weapon
{
    public Sword(BaseItemData data, float damage)
    {
        isBlocked = data.isBlocked;
        description = data.description;
        name = data.name;
        cost = data.cost;
        icon = data.icon;
        
        this.damage = damage;
    }
}
