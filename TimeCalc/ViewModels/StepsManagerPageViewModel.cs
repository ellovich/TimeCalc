using System.Windows.Input;
using ReactiveUI;
using Avalonia.Controls;
using TimeCalc.Views;

namespace TimeCalc.ViewModels
{
    public class StepsManagerPageViewModel : ViewModelBase
    {
        public ICommand ChooseStepCmd { get; }

        public StepsManagerPageViewModel()
        {
            ChooseStepCmd = ReactiveCommand.Create<Window>((w) =>
           {
               new StepsChooserWindow().ShowDialogSync(w);
           });
        }
    }
}
