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

        public FAQPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface) : base(pageService, cheapSharkAPI, sqliteInterface)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal void Init()
        {
            base.Init(SearchText);
        }
    }
}