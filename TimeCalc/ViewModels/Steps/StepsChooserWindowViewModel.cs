using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc.ViewModels
{
    public class StepsChooserWindowViewModel : ViewModelBase
    {
        [Reactive] public (int, string) SelectedStepTemplate { get; set; }
        public int StepId => SelectedStepTemplate.Item1;
        public string StepTemlateName => SelectedStepTemplate.Item2;


        [Reactive] public string StepEnteredName { get; set; }


        public ReactiveCommand<Window, Unit> AddStepCmd { get; }
        public ReactiveCommand<Window, Unit> CancelCmd { get; }

        public StepsChooserWindowViewModel()
        {
            CancelCmd = ReactiveCommand.Create<Window>(Close);

            AddStepCmd = ReactiveCommand.Create<Window>(
                execute: (w) =>
                {
                    StepsManager.CreateStep(StepId, StepEnteredName);
                    w.Close();
                },
                canExecute: this.WhenAnyValue(
                    x => x.StepId, x => x.StepEnteredName,
                    (id, name) => id != -1 && !string.IsNullOrWhiteSpace(name)));
        }
    }
}
