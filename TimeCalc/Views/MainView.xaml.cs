using System;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TimeCalc.ViewModels;

namespace TimeCalc.Views
{
    public class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
