using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private ShopController shopController;
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
            .Bind<ShopController>()
            .FromInstance(shopController)
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
