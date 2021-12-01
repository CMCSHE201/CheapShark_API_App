using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csApiApp.Mvvm.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public string search_Result;

        public HomePage()
        {
            InitializeComponent();
        }
    }
}