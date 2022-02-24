using csApiApp.Mvvm.Model;
using csApiApp.Services.Rest;
using csApiApp.Services;
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

        public SearchResultsDetailsVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface, Logger logger) : base(pageService, cheapSharkAPI, sqliteInterface, logger)
        {
            _pageService = pageService;
        }

        internal void Init(string searchText, SearchResult searchResult)
        {
            base.Init(searchText);
            SearchResult = searchResult;
        }
    }
}