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
    public class Steps16Page : UserControl
    {
        private Step16PageViewModel _vm;

        public Steps16Page()
        {
            InitializeComponent();
            _vm = new Step16PageViewModel(new Step16());
            DataContext = _vm;
        }

        public Steps16Page(Step step)
        {
            InitializeComponent();
            _vm = new Step16PageViewModel(step);
            DataContext = _vm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
