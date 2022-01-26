using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace csApiApp.Themes
{
    internal class ThemeSet
    {
        public static void Set()
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            Application.Current.Resources.MergedDictionaries.Clear();

            if (currentTheme != OSAppTheme.Light)
            {
                Application.Current.Resources.MergedDictionaries.Add(new Dark());
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new Light());
            }
        }
    }
}
