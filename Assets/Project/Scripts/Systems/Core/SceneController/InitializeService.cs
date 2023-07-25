using System.Collections.Generic;
using UnityEngine;

public class InitializeService : MonoBehaviour
{
    [SerializeField] private List<GameObject> _services;

    public void Awake()
    {
        InitializeServices();
    }

    private void InitializeServices()
    {
        foreach (var service in _services)
        {
            if (service.TryGetComponent<IInitializable>(out IInitializable initialieObj))
            {
                initialieObj.Initialize();
            }
        }
    }
}
