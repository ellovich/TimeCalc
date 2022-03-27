using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;
using TimeCalc.ViewModels;

namespace TimeCalc.Views
{
    public class Steps03Page : UserControl
    {
        private Step03PageViewModel _vm;

        public Steps03Page()
        {
            InitializeComponent();
            _vm = new Step03PageViewModel(new Step03());
            DataContext = _vm;
        }

        public Steps03Page(Step step)
        {
            InitializeComponent();
            _vm = new Step03PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            Border b = (Border)cb.Parent.Parent;
            Grid g = (Grid)b.GetVisualChildren().First();

            b.Background = new SolidColorBrush(Color.FromRgb(48, 48, 48));

            foreach (Control c in g.GetVisualChildren())
                c.IsEnabled = true;

            cb.IsEnabled = true;
        }

        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            Border b = (Border)cb.Parent.Parent;
            Grid g = (Grid)b.GetVisualChildren().First();

            b.Background = new SolidColorBrush(Color.FromRgb(89, 89, 89));

            foreach (Control c in g.GetVisualChildren())
            {
                if (!(c is TextBox))
                    c.IsEnabled = false;
            }

            cb.IsEnabled = true;
        }
    }
}
