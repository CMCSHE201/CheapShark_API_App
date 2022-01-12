using csApiApp.Models;
using csApiApp.Mvvm.View;
using csApiApp.Services.Rest;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace csApiApp.Mvvm.Vm
{
    public class BaseVm : FunctionZero.MvvmZero.MvvmZeroBaseVm
    {
        private readonly IPageServiceZero _pageService;
        private readonly CheapSharkAPI _cheapSharkAPI;

        public ICommand SettingsPageCommand { get; }

        public ObservableCollection<StoreResult> StoreList { get; set; }

        public ICommand AboutPageCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand StoreListCommand { get; }
        public ICommand FAQPageCommand { get; }
        public ICommand SearchPageCommand { get; }
        public ICommand DealsPageCommand { get; }
        public ICommand AddToWishlistCommand { get; }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set => base.SetProperty(ref _searchText, value);
        }

        public DealResult _dealResult;

        public BaseVm(IPageServiceZero pageService, CheapSharkAPI cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;
            _pageService = pageService;
            SettingsPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<Settings, SettingsVm>((vm) => vm.Init())).SetName("Settings").Build();
            GetStores();

            ViewDetailsCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<GameDetailsPage, GameDetailsPageVm>((vm) => vm.Init(_dealResult))).SetName("View Details").Build();
            AboutPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<AboutPage, AboutPageVm>((vm) => vm.Init())).SetName("About Us").Build();
            StoreListCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<StoreListPage, StoreListVm>((vm) => vm.Init())).SetName("Store List").Build();
            FAQPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<FAQPage, FAQPageVm>((vm) => vm.Init())).SetName("FAQ").Build();
            SearchPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<SearchPage, SearchPageVm>((vm) => vm.Init(SearchText))).SetName("Search").Build();
            DealsPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<DealsPage, DealsPageVm>((vm) => vm.Init())).SetName("View More Deals").Build();
            AddToWishlistCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(AddToWishlist).SetName("Wishlish (+)").Build();
        }

        internal async void GetStores()
        {
            var stores = await _cheapSharkAPI.GetStoresAsync();
            StoreList = new ObservableCollection<StoreResult>(stores);
        }

        private Task AddToWishlist()
        {
            throw new NotImplementedException();
        }
    }
}