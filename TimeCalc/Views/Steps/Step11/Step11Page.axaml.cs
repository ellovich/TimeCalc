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
    public class Steps11Page : UserControl
    {
        private Step11PageViewModel _vm;

        public Steps11Page()
        {
            InitializeComponent();
            _vm = new Step11PageViewModel(new Step11());
            DataContext = _vm;
        }

        public Steps11Page(Step step)
        {
            InitializeComponent();
            _vm = new Step11PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
