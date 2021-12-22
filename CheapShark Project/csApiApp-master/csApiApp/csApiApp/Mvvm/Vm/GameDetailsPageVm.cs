using csApiApp.Models;
using FunctionZero.MvvmZero;

namespace csApiApp.Mvvm.Vm
{
    public class GameDetailsPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;
        private DealResult _dealResult;

        public DealResult DealResult
        {
            get => _dealResult;
            set => base.SetProperty(ref _dealResult, value);
        }

        public GameDetailsPageVm(IPageServiceZero pageService) : base(pageService)
        {
            _pageService = pageService;
        }

        internal void Init(DealResult dealResult)
        {
            DealResult = dealResult;
        }
    }
}