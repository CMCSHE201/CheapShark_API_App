using csApiApp.Mvvm.Model;
using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class SearchResultsDetailsVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;
        private SearchResult _searchResults;

        public SearchResult SearchResult
        {
            get => _searchResults;
            set => base.SetProperty(ref _searchResults, value);
        }

        public SearchResultsDetailsVm(IPageServiceZero pageService) : base(pageService)
        {
            _pageService = pageService;
        }

        internal async void Init(SearchResult searchResult)
        {
            SearchResult = searchResult;
        }
    }
}