using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csApiApp.Mvvm.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : BasePage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void OnClick_Change(object sender, EventArgs e)
        {
            if (Application.Current.UserAppTheme == OSAppTheme.Dark)
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
        }
    }
}