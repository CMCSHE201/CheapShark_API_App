using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;
using System;

namespace csApiApp.Mvvm.Vm
{
    internal class FAQPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;
        private CheapSharkAPI _cheapSharkAPI;

        public FAQPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService) : base(pageService, cheapSharkAPI)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal void Init()
        {
        }
    }
}