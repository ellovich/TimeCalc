using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TimeCalc.Views
{
    public partial class StartUpWindow : Window
    {
        public StartUpWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
