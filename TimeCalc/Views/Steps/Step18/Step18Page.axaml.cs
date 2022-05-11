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
    public class Steps18Page : UserControl
    {
        private Step18PageViewModel _vm;

        public Steps18Page()
        {
            InitializeComponent();
            _vm = new Step18PageViewModel(new Step18());
            DataContext = _vm;
        }

        public Steps18Page(Step step)
        {
            InitializeComponent();
            _vm = new Step18PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
