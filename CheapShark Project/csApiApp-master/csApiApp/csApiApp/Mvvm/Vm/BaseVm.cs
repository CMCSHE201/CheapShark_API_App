using csApiApp.Mvvm.View;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System.Windows.Input;

namespace csApiApp.Mvvm.Vm
{
    public class BaseVm : FunctionZero.MvvmZero.MvvmZeroBaseVm
    {
        private readonly IPageServiceZero _pageService;

        public ICommand SettingsPageCommand { get; }

        public BaseVm(IPageServiceZero pageService)
        {
            _pageService = pageService;
            SettingsPageCommand = new CommandBuilder().AddGuard(this).SetExecuteAsync(async () => await _pageService.PushPageAsync<Settings, SettingsVm>((vm) => vm.Init())).SetName("Settings").Build();
        }
    }
}