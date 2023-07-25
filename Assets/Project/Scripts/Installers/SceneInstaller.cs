using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private CanvasSwitcher _canvasSwitcher;
    [SerializeField] private ShopService _shopService;
    [SerializeField] private InventoryService _inventoryService;
    [SerializeField] private TimeService _timeService;
    [SerializeField] private CurrencyViewService _currencyViewService;

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
            .Bind<CanvasSwitcher>()
            .FromInstance(_canvasSwitcher)
            .AsSingle();

        _canvasSwitcher.Initialize();
    }

    private void InstallShowViewController()
    {
        Container
            .Bind<ShopService>()
            .FromInstance(_shopService)
            .AsSingle();
    }

    private void InstallInventoryViewController()
    {
        Container
            .Bind<InventoryService>()
            .FromInstance(_inventoryService)
            .AsSingle();
    }

    private void InstallTimeController()
    {
        Container
            .Bind<TimeService>()
            .FromInstance(_timeService)
            .AsSingle();
    }

    private void InstallCurrencyViewController()
    {
        Container
            .Bind<CurrencyViewService>()
            .FromInstance(_currencyViewService)
            .AsSingle();
    }
}
