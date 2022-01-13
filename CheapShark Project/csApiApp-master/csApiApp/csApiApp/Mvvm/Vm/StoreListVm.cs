using csApiApp.Models;
using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using csApiApp.Services;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class StoreListVm : BaseVm
    {
        private CheapSharkAPI _cheapSharkAPI;
        private readonly IPageServiceZero _pageService;

        private ObservableCollection<StoreResult> _storeResults;

        public ObservableCollection<StoreResult> StoreResults
        {
            get => _storeResults;
            set => base.SetProperty(ref _storeResults, value);
        }

        public StoreListVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService) : base(pageService, cheapSharkAPI)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal async void Init(string searchText)
        {
            base.Init(searchText);
            var stores = await _cheapSharkAPI.GetStoresAsync();
            StoreResults = new ObservableCollection<StoreResult>(stores);
        }
    }
}