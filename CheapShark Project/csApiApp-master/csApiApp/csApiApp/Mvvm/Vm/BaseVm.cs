using csApiApp.Models;
using csApiApp.Mvvm.View;
using csApiApp.Services;
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
        private readonly SQLiteInterface _sqliteInterface;

        public ICommand SettingsPageCommand { get; }

        public ObservableCollection<Store> StoreList { get; set; }

        public ICommand HomePageCommand { get; }
        public ICommand AboutPageCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand StoreListCommand { get; }
        public ICommand FAQPageCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand DealsPageCommand { get; }
        public ICommand AddToWishlistCommand { get; }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set => base.SetProperty(ref _searchText, value);
        }

        public DealResult _dealResult;

        public BaseVm(IPageServiceZero pageService, CheapSharkAPI cheapSharkAPI, SQLiteInterface sqliteInterface)
        {
            _cheapSharkAPI = cheapSharkAPI;
            _pageService = pageService;
            _sqliteInterface = sqliteInterface;
            GetStores();

            HomePageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () =>
            {
                await _pageService.PopToRootAsync(false);
                await _pageService.PushPageAsync<HomePage, HomePageVm>((vm) => vm.Init(SearchText));
            }).SetName("Home").Build();

            SettingsPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () =>
            {
                await _pageService.PopToRootAsync(false);
                await _pageService.PushPageAsync<Settings, SettingsVm>((vm) => vm.Init(SearchText));
            }).SetName("Settings").Build();

            AboutPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () =>
            {
                await _pageService.PopToRootAsync(false);
                await _pageService.PushPageAsync<AboutPage, AboutPageVm>((vm) => vm.Init(SearchText));
            }).SetName("About Us").Build();

            StoreListCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () =>
            {
                await _pageService.PopToRootAsync(false);
                await _pageService.PushPageAsync<StoreListPage, StoreListVm>((vm) => vm.Init(SearchText));
            }).SetName("Store List").Build();

            FAQPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () =>
            {
                await _pageService.PopToRootAsync(false);
                await _pageService.PushPageAsync<FAQPage, FAQPageVm>((vm) => vm.Init(SearchText));
            }).SetName("FAQ").Build();

            SearchCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () =>
            {
                await _pageService.PopToRootAsync(false);
                await _pageService.PushPageAsync<SearchPage, SearchPageVm>((vm) => vm.Init(SearchText));
            }).SetName("Search").Build();

            DealsPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () =>
            {
                await _pageService.PopToRootAsync(false);
                await _pageService.PushPageAsync<DealsPage, DealsPageVm>((vm) => vm.Init(SearchText));
            }).SetName("View More Deals").Build();

            ViewDetailsCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<GameDetailsPage, GameDetailsPageVm>((vm) => vm.Init(SearchText, _dealResult))).SetName("View Details").Build();

            AddToWishlistCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(AddToWishlist).SetName("Wishlish (+)").Build();
        }

        public void Init(string searchText)
        {
            SearchText = searchText;
        }

        internal async void GetStores()
        {
            var stores = await _cheapSharkAPI.GetStoresAsync();
            StoreList = new ObservableCollection<Store>(stores);
            // Add the stores to the database
            _sqliteInterface.AddStores(stores);

        }

        private Task AddToWishlist()
        {
            throw new NotImplementedException();
        }
    }
}