using csApiApp.Services;
using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;

namespace csApiApp.Mvvm.Vm
{
    public class AboutPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public AboutPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface, Logger logger) : base(pageService, cheapSharkAPI, sqliteInterface, logger)
        {
            _pageService = pageService;
        }

        internal void Init(string searchText)
        {
            base.Init(searchText);
        }
    }
}