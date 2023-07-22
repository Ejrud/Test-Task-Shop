public interface ITimed
{
    public bool isRunning { get; set; }
    public bool isDeleted { get; set; }

    public void UpdateTime(float delta)
    {
        
    }

    public void SetTime()
    {
        
    }

    public float GetSeconds
    {
        get;
    }

    public string GetTime
    {
        get;
    }
}
