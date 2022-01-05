using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class GameDetailsVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public GameDetailsVm(IPageServiceZero pageService, CheapSharkAPI cheapSharkAPI) : base(pageService, cheapSharkAPI)
        {
            _pageService = pageService;
        }
    }
}