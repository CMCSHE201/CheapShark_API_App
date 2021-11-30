using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace csApiApp.Mvvm.Vm
{
    public class HomePageVm : BaseVm
    {
        //Deal of the day Image source property
        private ImageSource _dodImage;

        public ImageSource DodImage
        {
            get => _dodImage;
            set => base.SetProperty(ref _dodImage, value);
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

        public HomePageVm()
        {
            //base.AddPageTimer(10, MainTimerCallback, null, null);
            DodImage = ImageSource.FromResource("csApiApp.Images.test2.png");
            InitDealOfTheDay(); // WriteLines show expected values
        }

        private void MainTimerCallback(object obj)
        {
            Count++;
        }

        private async void InitDealOfTheDay()
        {
            List<GameResultClass> dealsOfTheDay = await _csAPI.GetDealsAsync(Constants.DealOfTheDayEndpoint);
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