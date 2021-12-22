﻿using csApiApp.Mvvm.Model;
using csApiApp.Mvvm.Vm;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csApiApp.Mvvm.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public ICommand SelectedCommand { get; }

        public SearchPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedResult = ((ListView)sender).SelectedItem as SearchResult;
            if (selectedResult == null)
            {
                return;
            }

            await DisplayAlert("Game Selected: ", selectedResult.External, "OK");
        }
    }
}