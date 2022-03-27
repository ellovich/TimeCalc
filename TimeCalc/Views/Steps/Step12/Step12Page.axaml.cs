using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TimeCalc.ViewModels;

namespace TimeCalc.Views
{
    public class Steps12Page : UserControl
    {
        private Step12PageViewModel _vm;

        public Steps12Page()
        {
            InitializeComponent();
            _vm = new Step12PageViewModel(new Step12());
            DataContext = _vm;
        }

        public Steps12Page(Step step)
        {
            InitializeComponent();

            _vm = new Step12PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void AddBigSubstep(object sender, RoutedEventArgs e)
        {
            //var table = new Step02Table(this, Step12PageViewModel);
            //this.Find<StackPanel>("SubstepsPanel").Children.Add(table);
        }

        private void AddSubstep(object sender, RoutedEventArgs e)
        {
            var dgv = this.Find<DataGrid>("Substeps");

            if (dgv.IsVisible)
                new Step02ItemsSelector().ShowDialog((Window)Parent);
            else
            {
                dgv.IsVisible = true;
                new Step02ItemsSelector().ShowDialog((Window)Parent.Parent.Parent.Parent.Parent.Parent);
            }
        }

        public void RemoveSubstep(Step02Table table)
        {
            this.Find<StackPanel>("SubstepsPanel").Children.Remove(table);
        }
    }
}
