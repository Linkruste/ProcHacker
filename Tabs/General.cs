using ProcHacker.Registry;
using ProcHacker.UI.Classes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProcHacker.Tabs
{
	public static class General
	{
		/// <summary>
		/// Sets Row and Column of an element in its parent grid.
		/// </summary>
		/// <param name="_element">Element to set row and column.</param>
		/// <param name="_row">Grid's row</param>
		/// <param name="_column">Grid's column</param>
		public static void SetRowCol(this UIElement _element,  int _row, int _column) 
		{
			Grid.SetRow(_element, _row);
			Grid.SetColumn(_element, _column);
		}

		public static void DevicesLibrary()
		{

		}

		/// <summary>
		/// Generates settings tab.
		/// </summary>
		/// <param name="_window">Parent window</param>
		/// <param name="_container">Grid container for content</param>
		public static void Settings(this MainWindow _window, ref Grid _container)
		{
            ActionButton _perfTest = new ActionButton("/UI/Assets/PerfTest.png");
			_perfTest.SetRowCol(0, 0);
			_perfTest.Click += (object sender, RoutedEventArgs e) => { new Task(PerfAndTests.Compare).Start(); MessageBox.Show("Calculating time...", "ProcHacker.exe is thinking", MessageBoxButton.OK, MessageBoxImage.Information);  };
			_container.Children.Add(_perfTest);

			ActionButton _savePrefs = new ActionButton("UI/Assets/SavePrefs.png");
			_savePrefs.SetRowCol(0, 1);
			_savePrefs.Click += (object sender, RoutedEventArgs e) => { UserPreferences.Settings.currentTheme = (byte)GlobalSettings.currentTheme; UserPreferences.Settings.SavePreferences(); };
			_container.Children.Add(_savePrefs);
		}
	}
}
