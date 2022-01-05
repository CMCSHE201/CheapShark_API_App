using csApiApp.Models;
using csApiApp.Mvvm.View;
using csApiApp.Services.Rest;
using csApiApp.Services.Rest.Endpoints;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace csApiApp.Mvvm.Vm
{
    public class HomePageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;
        private readonly CheapSharkAPI _cheapSharkAPI;

        //Deal of the day Image source property
        private string _dodImage;

        public string DodImage
        {
            get => _dodImage;
            set => base.SetProperty(ref _dodImage, value);
        }

        private int _dodGameId;

        public int DodGameId
        {
            get => _dodGameId;
            set => base.SetProperty(ref _dodGameId, value);
        }

        //Deal of the day game name property
        private string _dodName;

        public string DodName
        {
            get => _dodName;
            set => base.SetProperty(ref _dodName, value);
        }

        //Deal of the day origional game price property
        private string _dodOrigPrice;

        public string DodOrigPrice
        {
            get => _dodOrigPrice;
            set => base.SetProperty(ref _dodOrigPrice, value);
        }

        //Deal of the day current game price property
        private string _dodCurrentPrice;

        public string DodCurrentPrice
        {
            get => _dodCurrentPrice;
            set => base.SetProperty(ref _dodCurrentPrice, value);
        }

        //Deal of the day game cost saving property
        private string _dodSaving;

        public string DodSaving
        {
            get => _dodSaving;
            set => base.SetProperty(ref _dodSaving, value);
        }

        private long _count;

        public long Count
        {
            get => _count;
            set => base.SetProperty(ref _count, value);
        }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set => base.SetProperty(ref _searchText, value);
        }

        private DealResult _dealResult;

        public ICommand AboutPageCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand StoreListCommand { get; }
        public ICommand FAQPageCommand { get; }
        public ICommand SearchPageCommand { get; }

        public ICommand DealsPageCommand { get; }

        public ICommand AddToWishlistCommand { get; }

        public HomePageVm(IPageServiceZero pageService, CheapSharkAPI cheapSharkAPI) : base(pageService, cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;
            _pageService = pageService;

            base.AddPageTimer(10, MainTimerCallback, null, null);
            InitDealOfTheDay();

            ViewDetailsCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<GameDetailsPage, GameDetailsPageVm>((vm) => vm.Init(_dealResult))).SetName("View Details").Build();
            AboutPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<AboutPage, AboutPageVm>((vm) => vm.Init())).SetName("About Us").Build();
            StoreListCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<StoreListPage, StoreListVm>((vm) => vm.Init())).SetName("Store List").Build();
            FAQPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<FAQPage, FAQPageVm>((vm) => vm.Init())).SetName("FAQ").Build();
            SearchPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<SearchPage, SearchPageVm>((vm) => vm.Init(SearchText))).SetName("Search").Build();
            DealsPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<DealsPage, DealsPageVm>((vm) => vm.Init())).SetName("View More Deals").Build();

            AddToWishlistCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(AddToWishlist).SetName("Wishlish (+)").Build();
        }

        private Task AddToWishlist()
        {
            throw new NotImplementedException();
        }

        private void MainTimerCallback(object obj)
        {
            Count++;
        }

        private async void InitDealOfTheDay()
        {
            List<DealResult> dealsOfTheDay = new List<DealResult>();
            dealsOfTheDay = await _cheapSharkAPI.GetDealsAsync(Constants.DealOfTheDayEndpoint);
            DodGameId = dealsOfTheDay[0].GameID;
            DodName = dealsOfTheDay[0].Title;
            decimal costThen = dealsOfTheDay[0].NormalPrice;
            decimal costNow = dealsOfTheDay[0].SalePrice;
            int savingPercent = (int)(((costThen - costNow) / costThen) * 100);
            DodOrigPrice = $"£{costThen}";
            DodCurrentPrice = $"£{costNow}";
            DodSaving = $"{savingPercent}% Off!";
            DodImage = dealsOfTheDay[0].ThumbnailLink;

            _dealResult = dealsOfTheDay[0];
        }
    }
}