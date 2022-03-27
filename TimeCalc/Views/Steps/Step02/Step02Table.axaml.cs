using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TimeCalc.ViewModels;

namespace TimeCalc.Views
{
    public partial class Step02Table : UserControl
    {
        public Step02Table()
        {
            InitializeComponent();
            DataContext = new Step02TableViewModel();
        }

        public Step02Table(Steps02Page steps02Page, Step02PageViewModel step02PageViewModel)
        {
            InitializeComponent();
            DataContext = new Step02TableViewModel(this, steps02Page, step02PageViewModel);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void AddSubstep(object sender, RoutedEventArgs e)
        {
            new Step02ItemsSelector().ShowDialog((Window)Parent.Parent.Parent.Parent.Parent.Parent);
        }
    }
}
