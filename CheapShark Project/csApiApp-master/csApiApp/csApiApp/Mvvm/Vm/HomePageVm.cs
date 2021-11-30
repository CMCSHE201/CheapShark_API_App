using FunctionZero.CommandZero;
using csApiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace csApiApp.Mvvm.Vm
{
    public class HomePageVm : BaseVm
    {
        public ImageSource DodImage { get; set; }
        public string DodName { get; set; }
        public string DodOrigPrice { get; set; }
        public string DodCurrentPrice { get; set; }

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
            List<GameResultClass> dealsOfTheDay = await _restService.GetDealsAsync(Constants.DealOfTheDayEndpoint);
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