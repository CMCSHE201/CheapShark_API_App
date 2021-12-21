using Android.Content.Res;
using csApiApp.Mvvm.Model;
using csApiApp.Services.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    class SearchResultsDetailsVm : BaseVm
    {
        private SearchResult _searchResults;

        public SearchResult SearchResult
        {
            get => _searchResults;
            set => base.SetProperty(ref _searchResults, value);
        }

        public SearchResultsDetailsVm()
        {

        }

        internal async void Init(SearchResult searchResult)
        {
            SearchResult = searchResult;
        }
    }
}
