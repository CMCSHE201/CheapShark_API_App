using csApiApp.Models;
using csApiApp.Mvvm.View;
using csApiApp.Mvvm.Vm;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace csApiApp.Mvvm.Vm
{
    public class HomePageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        //Deal of the day Image source property
        private ImageSource _dodImage;

        public ImageSource DodImage
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

        public ICommand AboutPageCommand { get; }
        public ICommand ViewDetailsCommand { get; }

        public HomePageVm(IPageServiceZero pageService)
        {
            _pageService = pageService;

            base.AddPageTimer(10, MainTimerCallback, null, null);
            DodImage = ImageSource.FromResource("csApiApp.Images.test2.png");
            InitDealOfTheDay();

            ViewDetailsCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<GameDetailsPage, GameDetailsPageVm>((vm) => vm.Init(DodGameId))).SetName("View Details").Build();
            AboutPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<AboutPage, AboutPageVm>((vm) => vm.Init())).SetName("About Us").Build();
        }

        private void MainTimerCallback(object obj)
        {
            Count++;
        }

        private async void InitDealOfTheDay()
        {
            List<DealResult> dealsOfTheDay = await _csAPI.GetDealsAsync(Constants.DealOfTheDayEndpoint);
            DodGameId = dealsOfTheDay[0].GameID;
            DodName = dealsOfTheDay[0].Title;
            float costThen = dealsOfTheDay[0].NormalPrice;
            float costNow = dealsOfTheDay[0].SalePrice;
            int savingPercent = (int)(((costThen - costNow) / costThen) * 100);
            DodOrigPrice = $"£{costThen}";
            DodCurrentPrice = $"£{costNow}";
            DodSaving = $"{savingPercent}% Off!";
        }
    }
}