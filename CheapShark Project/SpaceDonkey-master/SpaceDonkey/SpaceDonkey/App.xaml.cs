using SpaceDonkey.Boilerplate;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpaceDonkey
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

            //MainPage = new MainPage();
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
