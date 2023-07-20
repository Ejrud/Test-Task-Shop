using UnityEngine;

public class TestItems : MonoBehaviour
{
    [SerializeField] private ItemStorage _itemStorage;
    [SerializeField] private ItemViewer _itemViewer;
    
    private void Start()
    {
        _itemStorage.Init();
        _itemViewer.Visualize(_itemStorage.items);
    }
}
