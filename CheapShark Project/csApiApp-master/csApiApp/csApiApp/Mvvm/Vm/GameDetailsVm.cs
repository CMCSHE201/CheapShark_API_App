using csApiApp.Services.Rest;
using csApiApp.Services;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    internal class GameDetailsVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public GameDetailsVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface, Logger logger) : base(pageService, cheapSharkAPI, sqliteInterface, logger)
        {
            _pageService = pageService;
        }
    }
}