using csApiApp.Mvvm.View;
using csApiApp.Mvvm.Vm;
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

            _iocc.Verify();
        }

        /// <summary>
        /// This is called once during application startup
        /// </summary>
        internal async Task SetFirstPage()
        {
            // Create and assign a top-level NavigationPage.
            // If you use a FlyoutPage instead then its Detail item will need to be a NavigationPage
            // and you will need to modify the 'navigationGetter' provided to the PageServiceZero instance to
            // something like this:
            // () => ((FlyoutPage)App.Current.MainPage).Detail.Navigation
            App.Current.MainPage = new NavigationPage();

            // Ask the PageService to assemble and present our HomePage ...
            await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<HomePage, HomePageVm>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });

            //await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<StoreListPage, StoreListVm>((vm) => vm.Init());
            //await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<AboutPage, AboutPageVm>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });
            //await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<FAQPage, FAQPageVm>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });
            //await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<SearchPage, SearchPageVm>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });
        }

        private IPageServiceZero GetPageService()
        {
            // This is how we create an instance of PageServiceZero.
            // The PageService needs to know how to get the current NavigationPage it is to interact with.
            // (If you have a FlyoutPage at the root, the navigationGetter should return the current Detail item)
            // It also needs to know how to get Page and ViewModel instances so we provide it with a factory
            // that uses the IoC container. We could easily provide any sort of factory, we don't need to use an IoC container.
            var pageService = new PageServiceZero(() => App.Current.MainPage.Navigation, (theType) => _iocc.GetInstance(theType));
            return pageService;
        }
    }
}