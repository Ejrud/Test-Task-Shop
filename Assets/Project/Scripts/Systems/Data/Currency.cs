[System.Serializable]
public class Currency
{
    public Currency(CurrencyType type, int value)
    {
        this.type = type;
        this.value = value;
    }

    public CurrencyType type;
    public int value;
}
