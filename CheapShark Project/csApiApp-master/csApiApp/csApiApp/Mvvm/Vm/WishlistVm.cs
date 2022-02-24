using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using csApiApp.Services;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    public class WishlistVm : BaseVm
    {
        public WishlistVm(IPageServiceZero pageService, CheapSharkAPI cheapSharkAPI, SQLiteInterface sqliteInterface, Logger logger) : base(pageService, cheapSharkAPI, sqliteInterface, logger)
        {
            GetStores();
        }
    }
}