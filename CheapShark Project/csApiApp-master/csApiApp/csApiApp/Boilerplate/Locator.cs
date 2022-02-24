using csApiApp.Mvvm.View;
using csApiApp.Mvvm.Vm;
using csApiApp.Services;
using csApiApp.Services.Rest;
using FunctionZero.MvvmZero;
using SimpleInjector;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace csApiApp.Boilerplate
{
    public class Locator
    {
        private Container _iocc;

        public Locator(Application currentApplication)
        {
            _iocc = new Container();

            _iocc.Register<IPageServiceZero>(GetPageService, Lifestyle.Singleton);
            _iocc.Register<HomePage>(Lifestyle.Singleton);
            _iocc.Register<HomePageVm>(Lifestyle.Singleton);
            _iocc.Register<AboutPage>(Lifestyle.Singleton);
            _iocc.Register<AboutPageVm>(Lifestyle.Singleton);
            _iocc.Register<StoreListPage>(Lifestyle.Singleton);
            _iocc.Register<StoreListVm>(Lifestyle.Singleton);
            _iocc.Register<GameDetailsPage>(Lifestyle.Singleton);
            _iocc.Register<GameDetailsPageVm>(Lifestyle.Singleton);
            _iocc.Register<FAQPage>(Lifestyle.Singleton);
            _iocc.Register<FAQPageVm>(Lifestyle.Singleton);
            _iocc.Register<SearchPage>(Lifestyle.Singleton);
            _iocc.Register<SearchPageVm>(Lifestyle.Singleton);
            _iocc.Register<SearchResultsDetails>(Lifestyle.Singleton);
            _iocc.Register<SearchResultsDetailsVm>(Lifestyle.Singleton);
            _iocc.Register<CheapSharkAPI>(Lifestyle.Singleton);
            _iocc.RegisterInstance<HttpClient>(new HttpClient());
            _iocc.Register<Settings>(Lifestyle.Singleton);
            _iocc.Register<SettingsVm>(Lifestyle.Singleton);
            _iocc.Register<DealsPage>(Lifestyle.Singleton);
            _iocc.Register<DealsPageVm>(Lifestyle.Singleton);
            _iocc.Register<BasePage>(Lifestyle.Singleton);
            _iocc.Register<BaseVm>(Lifestyle.Singleton);
            _iocc.RegisterInstance<SQLiteInterface>(new SQLiteInterface());
            _iocc.Register<Logger>(Lifestyle.Singleton);

            _iocc.Verify();
        }

        /// <summary>
        /// This is called once during application startup
        /// </summary>
        internal async Task SetFirstPage()
        {
            App.Current.MainPage = new NavigationPage();

            await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<HomePage, HomePageVm>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });

            //await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<StoreListPage, StoreListVm>((vm) => vm.Init());
            //await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<AboutPage, AboutPageVm>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });
            //await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<FAQPage, FAQPageVm>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });
            //await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<SearchPage, SearchPageVm>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });
        }

        private IPageServiceZero GetPageService()
        {
            var pageService = new PageServiceZero(() => App.Current.MainPage.Navigation, (theType) => _iocc.GetInstance(theType));
            return pageService;
        }
    }
}