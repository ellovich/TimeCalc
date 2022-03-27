using System;
using System.Collections.Generic;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using TimeCalc.ViewModels;

namespace TimeCalc.Views
{
    public partial class StepsChooserWindow : FluentWindow
    {
        public StepsChooserWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            FillComboBoxWithData();
        }

        public void FillComboBoxWithData()
        {
            var cb = this.Find<ComboBox>("StepTemplatesComboBox");
            cb.Items = StepsManager.s_StepsTemplates;
            cb.SelectedIndex = -1;
        }

        private void StepTemplatesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ((ComboBox)sender).SelectedItem;
            var tb = this.Find<TextBox>("StepNameTextBox");
            tb.Text = ((ValueTuple<int, string>)selected).Item2;
        }
    }
}
