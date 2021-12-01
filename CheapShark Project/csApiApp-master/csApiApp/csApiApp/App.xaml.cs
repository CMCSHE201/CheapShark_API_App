using csApiApp.Boilerplate;
using Xamarin.Forms;

namespace csApiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Create our Locator instance and tell it about the Application instance ...
            var locator = new Locator(this);

            // Ask the Locator to get us going. This is an asynchronous call from a constructor, so we're using the 'discard' ...
            _ = locator.SetFirstPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}