using csApiApp.Models;
using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;

namespace csApiApp.Mvvm.Vm
{
    public class GameDetailsPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;
        private readonly CheapSharkAPI _cheapSharkAPI;
        private DealResult _dealResult;
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

        public GameDetailsPageVm(IPageServiceZero pageService, CheapSharkAPI cheapSharkAPI) : base(pageService, cheapSharkAPI)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal void Init(DealResult dealResult)
        {
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