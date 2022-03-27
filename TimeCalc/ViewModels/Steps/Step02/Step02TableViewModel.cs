using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TimeCalc.Views;

namespace TimeCalc.ViewModels
{
    public class Step02TableViewModel : ViewModelBase
    {
        private Step02PageViewModel _step02PageViewModel { get; }
        public List<Item> SingleSteps { get; }
        [Reactive] public Table TableModel { get; set; }

        public Step02TableViewModel(Step02Table step02Table, Steps02Page step02Page, Step02PageViewModel step02PageViewModel)
        {
            _step02PageViewModel = step02PageViewModel;


            SingleSteps = Step02.SingleStepsItems;


            TableModel = new Table("");
            ((Step02)_step02PageViewModel.Step).AddedTables.Add(TableModel);


            #region Commands

            MoveUpCmd = ReactiveCommand.Create(() =>
            {
                Debug.WriteLine("MOVED UP");
            });

            MoveDownCmd = ReactiveCommand.Create(() =>
            {

            });

            EditSubstepsCmd = ReactiveCommand.Create<Window>((w) =>
            {
                new Step02ItemsSelector(step02Page, w, null, this, Step02.SingleStepsItems).ShowDialog(w);
            });

            RemoveSubstepCmd = ReactiveCommand.Create(() =>
            {
                ((Step02)_step02PageViewModel.Step).AddedTables.Remove(TableModel);
                step02Page.RemoveSubstep(step02Table);
            });

            #endregion
        }

        public Step02TableViewModel() { }

        public ICommand MoveUpCmd { get; set; }
        public ICommand MoveDownCmd { get; set; }
        public ICommand EditSubstepsCmd { get; set; }
        public ICommand RemoveSubstepCmd { get; set; }
    }
}
