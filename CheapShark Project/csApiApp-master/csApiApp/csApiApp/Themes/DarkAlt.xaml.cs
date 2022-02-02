using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csApiApp.Themes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DarkAlt : ResourceDictionary
    {
        public DarkAlt()
        {
            InitializeComponent();
        }
    }
}