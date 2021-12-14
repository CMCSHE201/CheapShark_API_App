using csApiApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    public class GameDetailsPageVm : BaseVm
    {
        private DealResult _dealResult;

        public DealResult DealResult
        {
            get => _dealResult;
            set => base.SetProperty(ref _dealResult, value);
        }

        public GameDetailsPageVm()
        {
        }

        internal void Init(DealResult dealResult)
        {
            DealResult = dealResult;
        }
    }
}