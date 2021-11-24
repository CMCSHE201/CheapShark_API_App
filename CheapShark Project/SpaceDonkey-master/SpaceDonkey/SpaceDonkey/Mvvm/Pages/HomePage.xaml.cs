using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpaceDonkey.Mvvm.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();
            InitSearchBar();
        }

        private void InitSearchBar()
        {
            sb_search.SearchButtonPressed += (s, e) => SearchDeal(sb_search.Text);
        }

        private void SearchDeal(string text)
        {
           search_Result.Text = text;
        }
    }
}