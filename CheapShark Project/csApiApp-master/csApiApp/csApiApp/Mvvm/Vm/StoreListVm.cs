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

        private ObservableCollection<Store> _storeResults;

        public ObservableCollection<Store> StoreResults
        {
            get => _storeResults;
            set => base.SetProperty(ref _storeResults, value);
        }

        public StoreListVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface, Logger logger) : base(pageService, cheapSharkAPI, sqliteInterface, logger)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal async void Init(string searchText)
        {
            base.Init(searchText);
            var stores = await _cheapSharkAPI.GetStoresAsync();
            StoreResults = new ObservableCollection<Store>(stores);
        }
    }
}