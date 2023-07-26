using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasSwitcherService : MonoBehaviour, IInitializable
{
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _inventoryButton;

    private Dictionary<CanvasType, GameObject> _canvasObjs;
    
    // В идеале нужно сделать что то более адекватное, т.к. если будут добавляться другие холсты,
    // то для каждого придется прописывать логику, но времени мало, сделал, что первое пришло в голову
    public void Initialize()
    {
        _canvasObjs = new Dictionary<CanvasType, GameObject>();
        _shopButton.onClick.AddListener(() => { OpenCanvasByType(CanvasType.Shop); });
        _inventoryButton.onClick.AddListener(() => { OpenCanvasByType(CanvasType.Inventory); });
    }

    public void OpenCanvasByType(CanvasType type)
    {
        if (_canvasObjs.TryGetValue(type, out GameObject canvas))
        {
            foreach (var unit in _canvasObjs)
                unit.Value.SetActive(false);
            
            canvas.SetActive(true);
        }
    }

    public void AddCanvas(CanvasType type, GameObject canvas)
    {
        _canvasObjs.Add(type, canvas);
    }

    public void RemoveCanvas(CanvasType type)
    {
        if (_canvasObjs.TryGetValue(type, out GameObject obj))
            _canvasObjs.Remove(type);
    }
}
