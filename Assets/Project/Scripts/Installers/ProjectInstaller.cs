using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private DataService _dataServicePrefab;
    [SerializeField] private DataInteraction _dataInteractionPrefab;
    [SerializeField] private VaultController _vaultController;
    
    public override void InstallBindings()
    {
        InstallDataController();
        InstallDataInteraction();
        InstallVaultController();
    }

    private void InstallDataController()
    {
        var gameInstance = Container
            .InstantiatePrefabForComponent<DataService>(_dataServicePrefab);
        
        Container
            .Bind<DataService>()
            .FromInstance(gameInstance)
            .AsSingle();
        
        gameInstance.Initialize();
    }

    private void InstallDataInteraction()
    {
        var gameInstance = Container
            .InstantiatePrefabForComponent<DataInteraction>(_dataInteractionPrefab);
        
        Container
            .Bind<DataInteraction>()
            .FromInstance(gameInstance)
            .AsSingle();
    }

    private void InstallVaultController()
    {
        var gameInstance = Container
            .InstantiatePrefabForComponent<VaultController>(_vaultController);
        
        Container
            .Bind<VaultController>()
            .FromInstance(gameInstance)
            .AsSingle();
        
        gameInstance.Initialize();
    }
}
