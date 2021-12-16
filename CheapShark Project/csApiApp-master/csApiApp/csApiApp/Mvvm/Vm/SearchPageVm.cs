using csApiApp.Mvvm.Model;
using csApiApp.Services.Rest;
using csApiApp.Services.Rest.Endpoints;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace csApiApp.Mvvm.Vm
{
    internal class SearchPageVm : BaseVm
    {
        private CheapSharkAPI _cheapSharkAPI;

        public ICommand SearchCommand { get; }

        private ObservableCollection<SearchResult> _searchResults;

        public ObservableCollection<SearchResult> SearchResults
        {
            get => _searchResults;
            set => base.SetProperty(ref _searchResults, value);
        }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set => base.SetProperty(ref _searchText, value);
        }

        public SearchPageVm(CheapSharkAPI cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;

            SearchCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(SearchGames).SetName("Search").Build();
        }

        internal async void Init(string text)
        {
            SearchText = text;
            await SearchGames();
        }

        internal async Task SearchGames()
        {
            string url = Constants.searchStartPoint + SearchText + Constants.searchEndPoint;
            var results = await _cheapSharkAPI.GetSearchAsync(url);
            SearchResults = new ObservableCollection<SearchResult>(results);
        }
    }
}