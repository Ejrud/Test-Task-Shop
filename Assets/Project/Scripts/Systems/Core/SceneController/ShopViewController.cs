using UnityEngine;
using Zenject;

public class ShopViewController : MonoBehaviour
{
    [SerializeField] private ItemViewer _itemViewer;
    private VaultController _vault;
    
    [Inject]
    public void Construct(VaultController vaultController)
    {
        _vault = vaultController;
        _itemViewer.Initialize(_vault.items);
    }
}
