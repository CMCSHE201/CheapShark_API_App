using csApiApp.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csApiApp.Mvvm.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : BasePage
    {
        public Settings()
        {
            InitializeComponent();
        }

        void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            Theme theme = (Theme)picker.SelectedItem;

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (theme)
                {
                    case Theme.Dark:
                    default:
                        mergedDictionaries.Add(new Dark());
                        break;
                    case Theme.DarkAlt:
                        mergedDictionaries.Add(new DarkAlt());
                        break;
                    case Theme.Light:
                        mergedDictionaries.Add(new Light());
                        break;
                    case Theme.LightAlt:
                        mergedDictionaries.Add(new LightAlt());
                        break;
                }
            }
        }
    }
}