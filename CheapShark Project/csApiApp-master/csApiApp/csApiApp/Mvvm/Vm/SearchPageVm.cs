using csApiApp.Mvvm.Model;
using csApiApp.Services.Rest;
using csApiApp.Services.Rest.Endpoints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class SearchPageVm : BaseVm
    {
        private CheapSharkAPI _cheapSharkAPI;

        private ObservableCollection<SearchResult> _searchResults;

        public ObservableCollection<SearchResult> SearchResults
        {
            get => _searchResults;
            set => base.SetProperty(ref _searchResults, value);
        }

        public SearchPageVm(CheapSharkAPI cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal async void Init(string text)
        {
            string url = Constants.searchStartPoint + text + Constants.searchEndPoint;
            var results = await _cheapSharkAPI.GetSearchAsync(url);
            SearchResults = new ObservableCollection<SearchResult>(results);
        }
    }
}
