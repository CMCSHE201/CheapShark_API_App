namespace csApiApp.Mvvm.Vm
{
    public class BaseVm : FunctionZero.MvvmZero.MvvmZeroBaseVm
    {
        public cheapSharkAPI _csAPI;

        public BaseVm()
        {
            _csAPI = new cheapSharkAPI();
        }
    }
}