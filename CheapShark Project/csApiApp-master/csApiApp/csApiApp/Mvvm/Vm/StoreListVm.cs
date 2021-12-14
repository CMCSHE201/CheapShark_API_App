using csApiApp.Models;
using csApiApp.Services.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class StoreListVm : BaseVm
    {
        private CheapSharkAPI _cheapSharkAPI;

        private ObservableCollection<StoreResult> _storeResults;

        public ObservableCollection<StoreResult> StoreResults
        {
            get => _storeResults;
            set => base.SetProperty(ref _storeResults, value);
        }

        public StoreListVm(CheapSharkAPI cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal async void Init()
        {
            var stores = await _cheapSharkAPI.GetStoresAsync();
            StoreResults = new ObservableCollection<StoreResult>(stores);
        }
    }
}