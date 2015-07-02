using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfControls.Utilities;

namespace WpfControls.Controls
{
    public class KeyPad : Grid
    {
        public KeyPad()
        {
            Width = 250;
            Height = 300;
            for (var i = 0; i < 3; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (var i = 0; i < 4; i++)
            {
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    string val;
                    if (j == 3)
                    {
                        val = i == 0 ? "." : i == 1 ? "0" : "<";
                    }
                    else
                    {
                        val = ((7 + i) - j * 3).ToString();
                    }
                    var tb = new Button
                    {
                        Content = val,
                        Style = (Style)FindResource("KeyPadButton"),
                        Padding = new Thickness(8, 5, 8, 5),
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Background = new SolidColorBrush(Color.FromRgb(100, 100, 100)),
                        Foreground = Brushes.White,
                        FontSize = 40,
                        Command = new Command(() =>
                        {
                            if (val == "<")
                            {
                                if (string.IsNullOrWhiteSpace(Text)) return;

                                Text = Text.Substring(0, Text.Length - 1);
                            }
                            else if (val != "." || !Text.Contains("."))
                            {
                                Text += val;
                            }
                        })
                    };
                    SetRow(tb, j);
                    SetColumn(tb, i);
                    Children.Add(tb);
                }
            }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(KeyPad), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
