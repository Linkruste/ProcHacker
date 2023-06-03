using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProcHacker
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string procname = "11th Gen Intel(R) Core(TM) i7-11800H @ 2.30GHz";
        public MainWindow()
        {
            InitializeComponent();
            RegistryManager.OverWriteKey(new Key("ProcessorNameString", "intaile caure", "HKLM:/HARDWARE/DESCRIPTION/System/CentralProcessor/0"));
        }
    }
}
