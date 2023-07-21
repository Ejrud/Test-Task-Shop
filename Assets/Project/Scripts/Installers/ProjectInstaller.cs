using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private DataController _dataControllerPrefab;
    [SerializeField] private VaultController vaultController;
    
    public override void InstallBindings()
    {
        InstallDataController();
        InstallVaultController();
    }

    private void InstallDataController()
    {
        var gameInstance = Container
            .InstantiatePrefabForComponent<DataController>(_dataControllerPrefab);
        
        Container
            .Bind<DataController>()
            .FromInstance(gameInstance)
            .AsSingle();
        
        gameInstance.Initialize();
    }

    private void InstallVaultController()
    {
        var gameInstance = Container
            .InstantiatePrefabForComponent<VaultController>(vaultController);
        
        Container
            .Bind<VaultController>()
            .FromInstance(gameInstance)
            .AsSingle();
        
        gameInstance.Initialize();
    }
}
