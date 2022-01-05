using csApiApp.Models;
using csApiApp.Mvvm.View;
using csApiApp.Services.Rest;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace csApiApp.Mvvm.Vm
{
    public class BaseVm : FunctionZero.MvvmZero.MvvmZeroBaseVm
    {
        private readonly IPageServiceZero _pageService;
        private readonly CheapSharkAPI _cheapSharkAPI;

        public ICommand SettingsPageCommand { get; }

        public ObservableCollection<StoreResult> StoreList { get; set; }

        public BaseVm(IPageServiceZero pageService, CheapSharkAPI cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;
            _pageService = pageService;
            SettingsPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<Settings, SettingsVm>((vm) => vm.Init())).SetName("Settings").Build();
            GetStores();
        }

        internal async void GetStores()
        {
            var stores = await _cheapSharkAPI.GetStoresAsync();
            StoreList = new ObservableCollection<StoreResult>(stores);
        }
    }
}