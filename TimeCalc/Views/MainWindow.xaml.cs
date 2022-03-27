using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TimeCalc.Views
{
    public class MainWindow : FluentWindow
    {
        public MainWindow()
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
