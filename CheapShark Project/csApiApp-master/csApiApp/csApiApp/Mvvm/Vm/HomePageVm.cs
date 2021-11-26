using FunctionZero.CommandZero;
using csApiApp.Models.Apod;
using csApiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace csApiApp.Mvvm.Vm
{
    public class HomePageVm : BaseVm
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

        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(PictureDate))
            {
                var result = await _apodService.GetApodAsync(PictureDate);

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
    }
}