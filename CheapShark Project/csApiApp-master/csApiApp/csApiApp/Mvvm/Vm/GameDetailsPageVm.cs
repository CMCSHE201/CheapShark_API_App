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
        private readonly Logger _logger;

        private Store _dealStore;

        public DealResult DealResult
        {
            get => _dealResult;
            set => base.SetProperty(ref _dealResult, value);
        }

        public Store DealStore
        {
            get => _dealStore;
            set => base.SetProperty(ref _dealStore, value);
        }

        public GameDetailsPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface, Logger logger) : base(pageService, cheapSharkAPI, sqliteInterface, logger)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
            _logger = logger;
        }

        internal void Init(string searchText, DealResult dealResult)
        {
            base.Init(searchText);
            DealResult = dealResult;

            int storeId = int.Parse(DealResult.StoreID);

            _logger.Log($"Getting store with id {storeId}");
            foreach (Store store in StoreList)
            {
                if (store.StoreID == storeId)
                {
                    _logger.Log($"Found store with id {storeId}");
                    DealStore = store;
                }
            }
        }
    }
}