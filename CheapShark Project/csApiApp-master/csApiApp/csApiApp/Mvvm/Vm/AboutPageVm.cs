﻿using FunctionZero.MvvmZero;

namespace csApiApp.Mvvm.Vm
{
    public class AboutPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public AboutPageVm(IPageServiceZero pageService) : base(pageService)
        {
            _pageService = pageService;
        }

        internal void Init()
        {
        }
    }
}