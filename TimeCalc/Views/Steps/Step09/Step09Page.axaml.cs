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
    public class Steps09Page : UserControl
    {
        private Step09PageViewModel _vm;

        public Steps09Page()
        {
            InitializeComponent();
            _vm = new Step09PageViewModel(new Step09());
            DataContext = _vm;
        }

        public Steps09Page(Step step)
        {
            InitializeComponent();
            _vm = new Step09PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
