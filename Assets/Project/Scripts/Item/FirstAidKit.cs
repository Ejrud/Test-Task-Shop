using Unity.VisualScripting.FullSerializer.Internal;

public class FirstAidKit : Health
{
    public FirstAidKit(float healtRegen, string name, float cost)
    {
        this.name = name;
        this.cost = cost;
        healthRegen = healtRegen;
    }
}
