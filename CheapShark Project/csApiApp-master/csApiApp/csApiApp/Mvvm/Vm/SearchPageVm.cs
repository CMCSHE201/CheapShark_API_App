using csApiApp.Mvvm.Model;
using csApiApp.Mvvm.View;
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
using Xamarin.Forms;

namespace csApiApp.Mvvm.Vm
{
    internal class SearchPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        private CheapSharkAPI _cheapSharkAPI;

        public ICommand SearchCommand { get; }

        public ICommand SelectedCommand { get; }

        private SearchResult selectedResult;

        public SearchResult SelectedResult
        {
            get => selectedResult;
            set
            {
                if (value != null)
                {
                    selectedResult = value;
                    SelectedCommand.Execute(selectedResult); ;
                }
            }
        }

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

        public SearchPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService) : base(pageService, cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;
            _pageService = pageService;

            SearchCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(SearchGames).SetName("Search").Build();

            // Can we not just use game/deal result classes/pages?
            SelectedCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<SearchResultsDetails, SearchResultsDetailsVm>((vm) => vm.Init(selectedResult))).SetName("View Details").Build();
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