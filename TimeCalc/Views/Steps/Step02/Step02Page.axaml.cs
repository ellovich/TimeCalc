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
    public class Steps02Page : UserControl
    {
        private Step02PageViewModel Step02PageViewModel { get; }

        public Steps02Page()
        {
            InitializeComponent();
            Step02PageViewModel = new Step02PageViewModel(new Step02());
            DataContext = Step02PageViewModel;
        }

        public Steps02Page(Step step)
        {
            InitializeComponent();
            Step02PageViewModel = new Step02PageViewModel(step);
            DataContext = Step02PageViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void AddSubstep(object sender, RoutedEventArgs e)
        {
            var w = (Window)this.Parent.Parent.Parent.Parent.Parent.Parent;
            new Step02ItemsSelector(this, w, Step02PageViewModel, null, Step02.ReadyStepsItems).ShowDialog(w);
        }

        public void RemoveSubstep(Step02Table table)
        {
            this.Find<StackPanel>("SubstepsPanel").Children.Remove(table);
        }
    }
}
