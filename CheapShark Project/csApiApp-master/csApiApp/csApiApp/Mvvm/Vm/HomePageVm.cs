using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace csApiApp.Mvvm.Vm
{
    public class HomePageVm : BaseVm
    {
        public ImageSource DodImage { get; set; }

        private string _dodName;

        public string DodName
        {
            get => _dodName;
            set => base.SetProperty(ref _dodName, value);
        }

        private string _dodOrigPrice;

        public string DodOrigPrice
        {
            get => _dodOrigPrice;
            set => base.SetProperty(ref _dodOrigPrice, value);
        }

        private string _dodCurrentPrice;

        public string DodCurrentPrice
        {
            get => _dodCurrentPrice;
            set => base.SetProperty(ref _dodCurrentPrice, value);
        }

        public HomePageVm()
        {
            DodImage = ImageSource.FromResource("csApiApp.Images.test2.png");
            InitDealOfTheDay(); // WriteLines show expected values
            DebugDod(); // All but DodImage return empty strings
        }

        private void DebugDod()
        {
            Debug.WriteLine("---Debug---");
            Debug.WriteLine(DodName);
            Debug.WriteLine(DodOrigPrice);
            Debug.WriteLine(DodCurrentPrice);
            Debug.WriteLine(DodImage);
            Debug.WriteLine("-----------");
        }

        private async void InitDealOfTheDay()
        {
            List<GameResultClass> dealsOfTheDay = await _csAPI.GetDealsAsync(Constants.DealOfTheDayEndpoint);
            DodName = dealsOfTheDay[0].Title;
            DodOrigPrice = $"£{dealsOfTheDay[0].NormalPrice}";
            DodCurrentPrice = $"£{dealsOfTheDay[0].SalePrice}";
            Debug.WriteLine(DodName);
            Debug.WriteLine(DodOrigPrice);
            Debug.WriteLine(DodCurrentPrice);
            Debug.WriteLine(DodImage);
        }
    }
}