using csApiApp.Models;
using csApiApp.Services.Rest;
using csApiApp.Services;
using FunctionZero.MvvmZero;

namespace csApiApp.Mvvm.Vm
{
    public class GameDetailsPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;
        private readonly CheapSharkAPI _cheapSharkAPI;
        private StoreResult _dealStore;

        public DealResult DealResult
        {
            get => _dealResult;
            set => base.SetProperty(ref _dealResult, value);
        }

        public StoreResult DealStore
        {
            get => _dealStore;
            set => base.SetProperty(ref _dealStore, value);
        }

        public GameDetailsPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService) : base(pageService, cheapSharkAPI)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal void Init(string searchText, DealResult dealResult)
        {
            base.Init(searchText);
            DealResult = dealResult;

            int storeId = int.Parse(DealResult.StoreID);

            foreach (StoreResult store in StoreList)
            {
                if (store.StoreID == storeId)
                {
                    DealStore = store;
                }
            }
        }
    }
}