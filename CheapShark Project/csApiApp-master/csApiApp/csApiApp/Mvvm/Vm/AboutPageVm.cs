using csApiApp.Services;
using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;

namespace csApiApp.Mvvm.Vm
{
    public class AboutPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public AboutPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService) : base(pageService, cheapSharkAPI)
        {
            _pageService = pageService;
        }

        internal void Init(string searchText)
        {
            base.Init(searchText);
        }
    }
}