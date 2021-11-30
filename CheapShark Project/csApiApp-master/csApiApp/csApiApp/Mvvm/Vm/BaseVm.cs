namespace csApiApp.Mvvm.Vm
{
    public class BaseVm : FunctionZero.MvvmZero.MvvmZeroBaseVm
    {
        public RestService _restService;

        public BaseVm()
        {
            _restService = new RestService();
        }
    }
}