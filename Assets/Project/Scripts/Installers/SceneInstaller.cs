using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private ShopService _shopService;
    [SerializeField] private InventoryService _inventoryService;
    [SerializeField] private TimeService _timeService;
    [SerializeField] private CurrencyViewService _currencyViewService;
    [SerializeField] private CanvasSwitcherService _canvasSwitcherService;

    public override void InstallBindings()
    {
        InstallShowViewController();
        InstallInventoryViewController();
        InstallTimeController();
        InstallCurrencyViewController();
        InstallCanvasSwitcherService();
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
    
    private void InstallCanvasSwitcherService()
    {
        Container
            .Bind<CanvasSwitcherService>()
            .FromInstance(_canvasSwitcherService)
            .AsSingle();
    }
}
