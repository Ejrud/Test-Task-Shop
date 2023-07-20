using UnityEngine;

public class TestItems : MonoBehaviour
{
    private void Start()
    {
        
    }
    
    [ContextMenu("DebugOut")]
    private void DebugOut()
    {
        FirstAidKit health = new FirstAidKit(10, "First aid kit", 129);
        Sword sword = new Sword(12, "Default sword", 123);
        
        Debug.Log(health.name);
        Debug.Log(sword.name);
    }
}
