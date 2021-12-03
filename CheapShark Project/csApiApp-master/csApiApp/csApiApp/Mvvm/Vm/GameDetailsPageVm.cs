using System;
using System.Collections.Generic;
using System.Text;

namespace csApiApp.Mvvm.Vm
{
    public class GameDetailsPageVm : BaseVm
    {
        private int _gameId;

        public int GameId
        {
            get => _gameId;
            set => base.SetProperty(ref _gameId, value);
        }

        public GameDetailsPageVm()
        {
        }

        internal void Init(int gameId)
        {
            GameId = gameId;
        }
    }
}