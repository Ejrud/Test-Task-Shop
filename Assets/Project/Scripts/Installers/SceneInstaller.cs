using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private ShopViewController _shopViewController;
    [SerializeField] private InventoryViewController _InventoryViewController;

    public override void InstallBindings()
    {
        InstallGameController();
        InstallShowViewController();
        InstallInventoryViewController();
    }

    private void InstallGameController()
    {
        Container
            .Bind<GameController>()
            .FromInstance(_gameController)
            .AsSingle();

        _gameController.Initialize();
    }

    private void InstallShowViewController()
    {
        Container
            .Bind<ShopViewController>()
            .FromInstance(_shopViewController)
            .AsSingle();
    }

    private void InstallInventoryViewController()
    {
        Container
            .Bind<InventoryViewController>()
            .FromInstance(_InventoryViewController)
            .AsSingle();
    }
}
