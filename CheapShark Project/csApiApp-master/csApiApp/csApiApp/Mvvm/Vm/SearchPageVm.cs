using csApiApp.Mvvm.Model;
using csApiApp.Mvvm.View;
using csApiApp.Services;
using csApiApp.Services.Rest;
using csApiApp.Services.Rest.Endpoints;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly Logger _logger;

        public ICommand SearchCommand { get; }

        public ICommand SelectedCommand { get; }

        public ICommand SortAscCommand
        {
            get
            {
                return new Command(() =>
                {
                    SortByLowestPrice();
                });
            }
        }

        public ICommand SortDescCommand
        {
            get
            {
                return new Command(() =>
                {
                    SortByHighestPrice();
                });
            }
        }

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

        public SearchPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface, Logger logger) : base(pageService, cheapSharkAPI, sqliteInterface, logger)
        {
            _cheapSharkAPI = cheapSharkAPI;
            _pageService = pageService;

            SearchCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(SearchGames).SetName("Search").Build();

            SelectedCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<SearchResultsDetails, SearchResultsDetailsVm>((vm) => vm.Init(SearchText, selectedResult))).SetName("View Details").Build();
        }

        internal async void Init(string searchText)
        {
            base.Init(searchText);
            await SearchGames();
        }

        internal async Task SearchGames()
        {
            _logger.Log($"Searching for {SearchText}");
            try
            {
            string url = Constants.searchStartPoint + SearchText + Constants.searchEndPoint;
            var results = await _cheapSharkAPI.GetSearchAsync(url);
            SearchResults = new ObservableCollection<SearchResult>(results);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }
        }

        public void SortByLowestPrice()
        {
            _logger.Log("Sorting by lowest price");
            if (SearchResults != null)
            {
                var sortedResults = SearchResults.OrderBy(x => x.Cheapest).ToList();

                for (int i = 0; i < sortedResults.Count; i++)
                {
                    SearchResults.Move(SearchResults.IndexOf(sortedResults[i]), i);
                }
            }
        }

        public void SortByHighestPrice()
        {
            _logger.Log("Sorting by highest price");
            if (SearchResults != null)
            {
                var sortedResults = SearchResults.OrderByDescending(x => x.Cheapest).ToList();

                for (int i = 0; i < sortedResults.Count; i++)
                {
                    SearchResults.Move(SearchResults.IndexOf(sortedResults[i]), i);
                }
            }
        }
    }
}