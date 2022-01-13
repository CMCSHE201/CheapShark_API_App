using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using csApiApp.Services;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class SettingsVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public SettingsVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService) : base(pageService, cheapSharkAPI)
        {
            _pageService = pageService;
        }

        internal void Init()
        {
            base.Init(SearchText);
        }
    }
}