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
    public class Steps07Page : UserControl
    {
        private Step07PageViewModel _vm;

        public Steps07Page()
        {
            InitializeComponent();
            _vm = new Step07PageViewModel(new Step07());
            DataContext = _vm;
        }

        public Steps07Page(Step step)
        {
            InitializeComponent();

            _vm = new Step07PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
