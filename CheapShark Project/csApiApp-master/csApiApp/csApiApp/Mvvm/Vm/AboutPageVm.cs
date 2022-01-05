using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;

namespace csApiApp.Mvvm.Vm
{
    public class AboutPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public AboutPageVm(IPageServiceZero pageService, CheapSharkAPI cheapSharkAPI) : base(pageService, cheapSharkAPI)
        {
            _pageService = pageService;
        }

        internal void Init()
        {
        }
    }
}