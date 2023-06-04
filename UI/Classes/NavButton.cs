using System.Reflection;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProcHacker.UI.Classes
{
    public class NavButton
    {
        public delegate int Click(NavButton sender);
        public event Click onClick;
        //TODO delegate and event that triggers when Radio "Click" event is triggered to access from NavButton class.

        public SolidColorBrush Tag { get; private set; }
        public Style Style { get; private set; }
        public string Text { get; private set; }
        public Image Icon { get; private set; }
        public int Tab;
        public RadioButton Button { get; private set; }

        /// <summary>
        /// Creates the navigation radio button
        /// </summary>
        /// <param Tag="_tag"></param>
        /// <param Text="_text"></param>
        /// <param Style="_style"></param>
        /// <param Icon="_icon"></param>
        /// <param Parent="_parent"></param>
        public NavButton(SolidColorBrush _tag, string _text, Style _style, Image _icon, StackPanel _parent)
        {
            Tag = _tag;
            Text = _text;
            Style = _style;
            Icon = _icon;
        }

        /// <summary>
        /// Displays the button from the specified StackPanel parent
        /// </summary>
        /// <param Parent="_parent"></param>
        public void Create(StackPanel _parent)
        {
            Button = new RadioButton() { Style = Style, Tag = Tag };
            Button.Click += button_Click; 
            TextBlock _txtBlock = new TextBlock() { Text = Text, Style = (Style)Application.Current.Resources["ButtonText"] };
            StackPanel _content = new StackPanel() { Orientation = Orientation.Horizontal };
            Icon.Style = (Style)Application.Current.Resources["ButtonIcon"];
            _content.Children.Add(Icon);
            _content.Children.Add(_txtBlock);
            Button.Content = _content;
            _parent.Children.Add(Button);
        }


        public void button_Click(object sender, RoutedEventArgs e)
        {
            onClick?.Invoke(this);
        }
    }
}
