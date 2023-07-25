using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private ShopController _shopController;
    [SerializeField] private InventoryController _inventoryController;
    [SerializeField] private TimeController _timeController;
    [SerializeField] private CurrencyViewController _currencyViewController;

    public override void InstallBindings()
    {
        InstallGameController();
        InstallShowViewController();
        InstallInventoryViewController();
        InstallTimeController();
        InstallCurrencyViewController();
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
            .FromInstance(_shopController)
            .AsSingle();
    }

    private void InstallInventoryViewController()
    {
        Container
            .Bind<InventoryController>()
            .FromInstance(_inventoryController)
            .AsSingle();
    }

    private void InstallTimeController()
    {
        Container
            .Bind<TimeController>()
            .FromInstance(_timeController)
            .AsSingle();
    }

    private void InstallCurrencyViewController()
    {
        Container
            .Bind<CurrencyViewController>()
            .FromInstance(_currencyViewController)
            .AsSingle();
    }
}
