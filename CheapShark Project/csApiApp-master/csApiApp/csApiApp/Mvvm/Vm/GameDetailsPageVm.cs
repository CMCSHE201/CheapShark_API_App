using csApiApp.Models;

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