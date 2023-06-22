using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ProcHacker.UI.Classes
{
    public static class UITools
    {
        public static class UIBrushes
        {
            /// <summary>Transparent SolidColorBrush.</summary>
            public static SolidColorBrush Transparent = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        public static class Dictionaries
        {
            const string ThemesPath = "/UI";

            public static List<string> Themes = new List<string>
            {
                $"{ThemesPath}/DeepSea.xaml", 
                $"{ThemesPath}/Reddish.xaml", 
                $"{ThemesPath}/Global warning.xaml",
                $"{ThemesPath}/Dark.xaml", 
            };
        }
    }
}
