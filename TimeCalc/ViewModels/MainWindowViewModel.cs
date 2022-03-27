using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TimeCalc.Views;

namespace TimeCalc.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        [Reactive] public ObservableCollection<TabItem> Tabs { get; set; }
        public TabItem StepManagerPageTab { get; set; }

        public MainWindowViewModel()
        {
            StepManagerPageTab = new TabItem() { Header = "Все этапы", Content = new StepsManagerPage() };

            Tabs = new ObservableCollection<TabItem>() { StepToTabItemConverter.Convert(StepsManager.DoneSteps) };
            Tabs.Insert(0, StepManagerPageTab);

            // сделать чтобы не удалялись старые вкладки
            StepsManager.DoneSteps.CollectionChanged += (obj, args) =>
            {
                Tabs.Clear();
                Tabs.Add(StepManagerPageTab);
                Tabs.AddRange(StepToTabItemConverter.Convert(StepsManager.DoneSteps));
            };


            #region MENU COMMANDS

            NewCmd = ReactiveCommand.Create(() => Console.Beep());
            OpenCmd = ReactiveCommand.Create(() => Console.Beep());
            SaveCmd = ReactiveCommand.Create(() => Console.Beep());
            ExitCmd = ReactiveCommand.Create(() => Console.Beep());

            ExportToHtmlCmd = ReactiveCommand.CreateFromTask(() =>
            {
                return Task.Run(() => Report.Show());
            });
            ExportToExcelCmd = ReactiveCommand.Create(() => Console.Beep());
            MailMeCmd = ReactiveCommand.Create(() => Console.Beep());

            #endregion
        }


        #region MENU COMMANDS

        public ICommand NewCmd { get; set; }
        public ICommand OpenCmd { get; set; }
        public ICommand SaveCmd { get; set; }
        public ICommand ExitCmd { get; set; }

        public ICommand ExportToHtmlCmd { get; set; }
        public ICommand ExportToExcelCmd { get; set; }
        public ICommand MailMeCmd { get; set; }

        #endregion

    }
}
