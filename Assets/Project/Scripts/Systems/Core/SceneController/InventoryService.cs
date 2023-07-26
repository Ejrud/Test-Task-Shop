using UnityEngine;
using Zenject;

public class InventoryService : MonoBehaviour, IInitializable
{
    [SerializeField] private InventoryView _viewPrefab;
    private CanvasSwitcherService _canvasSwitcherService;
    private DataInteraction _dataInteraction;
    private InventoryView _view;
    
    [Inject]
    public void Construct(DataInteraction dataInteraction, CanvasSwitcherService canvasSwitcherService)
    {
        _dataInteraction = dataInteraction;
        _canvasSwitcherService = canvasSwitcherService;
    }
    
    public void Initialize()
    {
        _dataInteraction.OnItemDataChanged += UpdateList;
        _view = Instantiate(_viewPrefab);
        _canvasSwitcherService.AddCanvas(_view.canvasType, _view.gameObject);
        UpdateList();
    }

    private void UpdateList()
    {
        _view.UpdateList(_dataInteraction.GetUserItems());
    }

    private void OnDestroy()
    {
        if (_dataInteraction)
            _dataInteraction.OnItemDataChanged -= UpdateList;
        
        if (_canvasSwitcherService)
            _canvasSwitcherService.RemoveCanvas(_view.canvasType);
    }
}
