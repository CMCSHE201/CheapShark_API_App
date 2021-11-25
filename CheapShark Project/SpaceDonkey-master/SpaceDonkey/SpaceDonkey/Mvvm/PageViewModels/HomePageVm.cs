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

namespace SpaceDonkey.Mvvm.PageViewModels
{
    public class HomePageVm : SpaceDonkeyBaseVm
    {


        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

        }
    }
}