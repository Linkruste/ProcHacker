using ProcHacker.UI.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProcHacker
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // It's mine though
        const string origProcname = "11th Gen Intel(R) Core(TM) i7-11800H @ 2.30GHz";
        // And this one is for tests
        const string procname = "Barely working toaster 90Ghz";
        public List<NavButton> Buttons;
        int activeTab = 0;
        TextBox Txtb1;
        TextBlock Txtb2;
        Image CPUEdit = new Image { Source = new BitmapImage(new Uri("/UI/Assets/CPU_Edit.png", UriKind.Relative)) };
        Image CPUView = new Image { Source = new BitmapImage(new Uri("/UI/Assets/CPU_Overview.png", UriKind.Relative)) };

        public MainWindow()
        {
            InitializeComponent();
            InitUI();
            InitButtonsList();
            InitButtons();
            Buttons[0].button_Click(Buttons[0], new RoutedEventArgs());
        }

        /// <summary>
        /// Create the Navigation buttons list and the buttons in it.
        /// </summary>
        /// <returns>Nothing lol.</returns>
        private void InitButtonsList()
        {
            Buttons = new List<NavButton>
            {
                new NavButton((SolidColorBrush)GetResource("color1"), "CPU",        (Style)GetResource("NavButton"), new Image { Source = new BitmapImage(new Uri("/UI/Assets/CPU_Edit.png", UriKind.Relative)) }, NavContainer),
                new NavButton((SolidColorBrush)GetResource("color3"), "Settings",   (Style)GetResource("NavButton"), new Image { Source = new BitmapImage(new Uri("/UI/Assets/Settings.png", UriKind.Relative)) }, NavContainer)
            };
        }

        int changeTab(NavButton sender)
        {
            activeTab = sender.Tab;
            //MessageBox.Show($"{activeTab}");
            return activeTab;
        }

        /// <summary>
        /// Displays all buttons on the screen.
        /// </summary>
        private void InitButtons()
        {
            NavContainer.Children.Clear();
            StackPanel _brand = new StackPanel { Height = 30, Margin = new Thickness(10, 30, 0, 40), Orientation = Orientation.Horizontal };
            _brand.Children.Add(new Image { Height = 30, HorizontalAlignment = HorizontalAlignment.Left, Source = new BitmapImage(new Uri(@"/UI/Assets/CPU.png", UriKind.Relative)) });
            _brand.Children.Add(new TextBlock { Text = "ProcHacker", FontFamily = new FontFamily("Candara"), Margin = new Thickness(10, 0, 0, 0), Foreground = (Brush)Application.Current.Resources["Title1"], VerticalAlignment = VerticalAlignment.Center, FontSize = 16 });

            NavContainer.Children.Add(_brand);
            foreach (NavButton _button in Buttons)
                _button.Create(NavContainer);
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].Tab = i;
                Buttons[i].onClick += changeTab;
            }
        }

        /// <summary>
        /// An alias to get Resources faster.
        /// </summary>
        /// <returns>The resource specified by the given name.</returns>
        object GetResource(string _name) => Application.Current.Resources[_name];

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                Left = System.Windows.Forms.Cursor.Position.X - Width / 2;
                Top = System.Windows.Forms.Cursor.Position.Y - Height / 2;
            }
            if (e.ChangedButton == MouseButton.Left && WindowState != WindowState.Maximized)
                DragMove();
            if (e.ChangedButton == MouseButton.Middle)
                Close();
        }

        private void Window_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Displays current CPU info
        /// </summary>
        private void RefreshCPUInfo(object sender, RoutedEventArgs e) => Txtb2.Text = RegistryManager.ReadKey(new Key(Key.KeyPath[Key.KeyType.ProcessorName], "ProcessorNameString"));
        /// <summary>
        /// Write data specified in the textbox to the CPU keys into registry.
        /// </summary>
        private void EditCPUInfo(object sender, RoutedEventArgs e)
        {
            if (RegistryManager.OverWriteKey(new Key(Key.KeyPath[Key.KeyType.ProcessorName], "ProcessorNameString", Txtb1.Text)))
                Txtb1.Foreground = (Brush)GetResource("color2");
            else
                Txtb1.Foreground = (Brush)GetResource("color3");
        }

        /// <summary>
        /// Create all CPU page UI elements and interactions.
        /// </summary>
        private void InitUI()
        {
            Content.Children.Clear();

            Button _EditCPUButton = new Button
            {
                Background = Transparent(),
                BorderBrush = Transparent(),
                Content = CPUEdit
            };
            _EditCPUButton.Click += EditCPUInfo;
            _EditCPUButton.Content = CPUEdit;

            Button _ViewCPUButton = new Button
            {
                Background = Transparent(),
                BorderBrush = Transparent(),
                Content = CPUView
            };
            _ViewCPUButton.Click += RefreshCPUInfo;
            _ViewCPUButton.Content = CPUView;
            Grid.SetColumn(_ViewCPUButton, 1);
            Grid.SetRow(_ViewCPUButton, 0);

            TextBox Txtbx1 = new TextBox
            {
                Height = 30,
                Width = 300,
                Foreground = (SolidColorBrush)GetResource("Title1"),
                Background = (SolidColorBrush)GetResource("NavPanelActiveButton"),
                BorderBrush = Transparent(),
                CaretBrush = (SolidColorBrush)GetResource("Text1"),
                FontFamily = new FontFamily("Cascadia Code SemiBold"),
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Name = "Txtb1",
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Txtbx1.TextChanged += ResetTextBoxColor;
            Grid.SetColumn(Txtbx1, 0);
            Grid.SetRow(Txtbx1, 1);

            Border _wrapper = new Border { Background = Transparent(), VerticalAlignment = VerticalAlignment.Center };
            TextBlock Txtbx2 = new TextBlock
            {
                Height = 30,
                Width = 300,
                Foreground = (SolidColorBrush)GetResource("Text1"),
                Background = (SolidColorBrush)GetResource("NavPanelOverButton"),
                FontFamily = new FontFamily("Cascadia Code SemiBold"),
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                Name = "Txtb2",
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Grid.SetColumn(_wrapper, 1);
            Grid.SetRow(_wrapper, 1);
            _wrapper.Child = Txtbx2;


            Content.Children.Add(_EditCPUButton);
            Content.Children.Add(Txtbx1);
            Content.Children.Add(_ViewCPUButton);
            Content.Children.Add(_wrapper);

            Txtb1 = Txtbx1;
            Txtb2 = Txtbx2;
        }

        /// <returns>Transparent SolidColorBrush.</returns>
        private SolidColorBrush Transparent() => new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

        /// <summary>
        /// Reset Textbox color each time we type a new character inside of it.
        /// </summary>
        private void ResetTextBoxColor(object sender, TextChangedEventArgs e) => Txtb1.Foreground = (SolidColorBrush)GetResource("Title1");
    }
}
