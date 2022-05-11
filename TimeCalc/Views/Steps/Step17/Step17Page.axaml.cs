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
    public class Steps17Page : UserControl
    {
        private Step17PageViewModel _vm;

        public Steps17Page()
        {
            InitializeComponent();
            _vm = new Step17PageViewModel(new Step17());
            DataContext = _vm;
        }

        public Steps17Page(Step step)
        {
            InitializeComponent();
            _vm = new Step17PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
