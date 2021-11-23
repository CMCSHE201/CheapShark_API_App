using FunctionZero.CommandZero;
using SpaceDonkey.Models.Apod;
using SpaceDonkey.Mvvm.ViewModels;
using SpaceDonkey.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpaceDonkey.Mvvm.PageViewModels
{
    public class HomePageVm : SpaceDonkeyBaseVm
    {
        private ApodResponse _apodData;
        private DateTime _pictureDate;
        private readonly ApodService _apodService;

        public ApodResponse ApodData
        {
            get => _apodData;
            set => SetProperty(ref _apodData, value);
        }

        public DateTime PictureDate
        {
            get => _pictureDate;
            set => SetProperty(ref _pictureDate, value);
        }

        public HomePageVm(ApodService apodService)
        {
            _apodService = apodService;
            PictureDate = DateTime.Now;
        }

        protected async void FindDealOfTheDay()
        {
            var result = await _apodService.GetApodAsyncStart();

            if (result.status == Services.Rest.ResultStatus.Success)
            {
                ApodData = result.payload.FirstOrDefault();
            }
            else
            {
                ApodData = null;
            }
        }

        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == nameof(PictureDate))
            {
                //var result = await _apodService.GetApodAsync(PictureDate);

                var result = await _apodService.GetApodAsyncStart();

                if (result.status == Services.Rest.ResultStatus.Success)
                {
                    ApodData = result.payload.FirstOrDefault();
                }
                else
                {
                    ApodData = null;
                }
            }
        }
        /*protected async void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;

            var result = await _apodService.GetApodAsyncStart();

            if (result.status == Services.Rest.ResultStatus.Success)
            {
                ApodData = result.payload.FirstOrDefault();
            }
            else
            {
                ApodData = null;
            }
        }*/


    }
}
