using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class SettingsVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public SettingsVm(IPageServiceZero pageService) : base(pageService)
        {
            _pageService = pageService;
        }

        internal void Init()
        {
        }
    }
}