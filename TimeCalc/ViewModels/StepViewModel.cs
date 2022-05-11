using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TimeCalc.Views;

namespace TimeCalc.ViewModels
{
    public class StepViewModel : ViewModelBase
    {
        [Reactive] public Step Step { get; set; }

        public ICommand DeleteStepCmd { get; set; }

        public StepViewModel(Step step)
        {
            Step = step;

            DeleteStepCmd = ReactiveCommand.Create(() =>
            {
                StepsManager.DoneSteps.Remove(Step);
            });
        }

        public static UserControl CreateView(Step step)
        {
            switch (step.MethodicId)
            {
                //case 1:  return new Steps01Page(step);
                case 2:  return new Steps02Page(step);
                case 3:  return new Steps03Page(step);
                //case 4:  return new Steps04Page(step);
                //case 5:  return new Steps05Page(step);
                case 6:  return new Steps06Page(step);
                case 7:  return new Steps07Page(step);
                //case 8:  return new Steps08Page(step);
                case 9:  return new Steps09Page(step);
                //case 10: return new Steps10Page(step);
                case 11: return new Steps11Page(step);
                case 12: return new Steps12Page(step);
                //case 13: return new Steps13Page(step);
                case 14: return new Steps14Page(step);
                //case 15: return new Steps15Page(step);
                case 16: return new Steps16Page(step);
                case 17: return new Steps17Page(step);
                case 18: return new Steps18Page(step);
                default: throw new Exception();
            }
        }
    }
}
