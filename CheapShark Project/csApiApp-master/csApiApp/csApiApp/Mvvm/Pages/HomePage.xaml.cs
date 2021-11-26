using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            InitSearchBar();
        }

        private void InitSearchBar()
        {
            sb_Search.SearchButtonPressed += (s, e) => SearchDeal(sb_Search.Text);
        }

        private void SearchDeal(string text)
        {
            search_Result = text;
            search_Result_Text.Text = search_Result;
        }
    }
}