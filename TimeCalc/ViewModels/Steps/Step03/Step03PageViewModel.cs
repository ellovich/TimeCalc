using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TimeCalc;
using TimeCalc.Views;

namespace TimeCalc.ViewModels
{
    public class Step03PageViewModel : StepViewModel
    {
        public Step03PageViewModel(Step step) : base(step)
        {
        }
    }
}
