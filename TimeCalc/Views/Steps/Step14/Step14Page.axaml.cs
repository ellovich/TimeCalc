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
    public class Steps14Page : UserControl
    {
        private Step14PageViewModel _vm;

        public Steps14Page()
        {
            InitializeComponent();
            _vm = new Step14PageViewModel(new Step14());
            DataContext = _vm;
        }

        public Steps14Page(Step step)
        {
            InitializeComponent();
            _vm = new Step14PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
