using csApiApp.Models;
using csApiApp.Mvvm.Model;
using csApiApp.Services.Rest;
using csApiApp.Services.Rest.Endpoints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class SearchResultsVm : BaseVm
    {
        private CheapSharkAPI _cheapSharkAPI;

        private List<SearchResult> _searchResults;

        public List<SearchResult> GameResults
        {
            get => _searchResults;
            set => base.SetProperty(ref _searchResults, value);
        }

        public SearchResultsVm(CheapSharkAPI cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal async void Init(string text)
        {
            var games = await _cheapSharkAPI.GetSearchAsync(text);
            GameResults = new List<SearchResult>(games);
        }
    }
}
