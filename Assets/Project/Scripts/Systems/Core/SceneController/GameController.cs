using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _shopCanvas;
    [SerializeField] private GameObject _inventoryCanvas;
    
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _inventoryButton;

    public void Initialize()
    {
        SetLayout(true, false);
        
        _shopButton.onClick.AddListener(() =>
        {
            SetLayout(true, false);
        }); 
        
        _inventoryButton.onClick.AddListener(() =>
        {
            SetLayout(false, true);
        });
    }

    private void SetLayout(bool shop, bool inventory)
    {
        _shopCanvas.SetActive(shop);
        _inventoryCanvas.SetActive(inventory);
    }
}
