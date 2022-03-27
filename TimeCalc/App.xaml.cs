using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using TimeCalc.Views;
using TimeCalc.ViewModels;

namespace TimeCalc
{
    public class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<StepsManager>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            //INavigationService homeNavService = CreateHomeNavService();
            //homeNavService.Navigate();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
