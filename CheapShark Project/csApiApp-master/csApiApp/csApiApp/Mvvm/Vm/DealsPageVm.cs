using csApiApp.Models;
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

namespace csApiApp.Mvvm.Vm
{
    internal class DealsPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        private CheapSharkAPI _cheapSharkAPI;

        public ICommand SelectedCommand { get; }

        private DealResult selectedDeal;

        public DealResult SelectedDeal
        {
            get => selectedDeal;
            set
            {
                if (value != null)
                {
                    selectedDeal = value;
                    SelectedCommand.Execute(selectedDeal); ;
                }
            }
        }

        private ObservableCollection<DealResult> _dealResults;

        public ObservableCollection<DealResult> DealResults
        {
            get => _dealResults;
            set => base.SetProperty(ref _dealResults, value);
        }

        public DealsPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService) : base(pageService, cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;
            _pageService = pageService;

            // Can we not just use game/deal result classes/pages?
            SelectedCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<GameDetailsPage, GameDetailsPageVm>((vm) => vm.Init(selectedDeal))).SetName("View Details").Build();
        }

        internal async void Init()
        {
            await FindDeals();
        }

        internal async Task FindDeals()
        {
            string url = Constants.FindDealsEndpoint;
            var results = await _cheapSharkAPI.GetDealsAsync(url);
            DealResults = new ObservableCollection<DealResult>(results);
        }
    }
}