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
    public class Steps06Page : UserControl
    {
        private Step03PageViewModel _vm;

        public Steps06Page()
        {
            InitializeComponent();
            _vm = new Step03PageViewModel(new Step06());
            DataContext = _vm;
        }

        public Steps06Page(Step step)
        {
            InitializeComponent();
            _vm = new Step03PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
