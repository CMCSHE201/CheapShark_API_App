using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csApiApp.Mvvm.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavMenu : FlyoutPage
    {
        public NavMenu()
        {
            InitializeComponent();
            MyMenu();
        }

        public void MyMenu()
        {
            Detail = new NavigationPage(new View.HomePage());
            List<Menu> menu = new List<Menu>
            {
                new Menu{ Page = new View.HomePage(), MenuTitle="Home", MenuDetail="", Icon=""},
                new Menu{ Page = new View.HomePage(), MenuTitle="Games",  MenuDetail="All Games", Icon=""},
                new Menu{ Page = new View.HomePage(), MenuTitle="Search",  MenuDetail="Search deals", Icon=""},
                new Menu{ Page = new View.HomePage(), MenuTitle="Search by Store",  MenuDetail="List of deals available at a specific store", Icon=""},
                new Menu{ Page = new View.HomePage(), MenuTitle="Search by Genre", MenuDetail="List of deals organised by Genre", Icon=""},
                new Menu{ Page = new View.HomePage(), MenuTitle="Best Deals", MenuDetail="List of the best available deals", Icon=""},
                new Menu{ Page = new View.Settings(), MenuTitle="Settings", MenuDetail="Change app settings", Icon=""},
                new Menu{ Page = new View.HomePage(), MenuTitle="About", MenuDetail="About us", Icon=""}
            };
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Menu menu)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }

        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }

            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource Icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }
    }
}