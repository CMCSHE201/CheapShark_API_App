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

namespace csApiApp.Mvvm.Vm
{
    public class HomePageVm : BaseVm
    {
        private ImageSource _dodImage;

        public ImageSource DodImage
        {
            get { return _dodImage; }
            set
            {
                _dodImage = value;
                SetProperty(ref _dodImage, value);
            }
        }

        public HomePageVm()
        {
            DodImage = ImageSource.FromResource("csApiApp.Images.test2.png");
        }
    }
}