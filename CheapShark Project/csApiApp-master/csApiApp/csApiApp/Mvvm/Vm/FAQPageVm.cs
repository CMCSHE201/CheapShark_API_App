using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;
using System;
using csApiApp.Services;

namespace csApiApp.Mvvm.Vm
{
    internal class FAQPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;
        private CheapSharkAPI _cheapSharkAPI;
        private readonly Logger _logger;

        public FAQPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface, Logger logger) : base(pageService, cheapSharkAPI, sqliteInterface, logger)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
            _logger = logger;
        }

        internal void Init()
        {
            base.Init(SearchText);
        }
    }
}