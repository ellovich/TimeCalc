using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using Avalonia.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject
    {
        /// <summary> Синглтон StepsManager`а </summary>
        public StepsManager StepsManager { get; } = StepsManager.Instance;

        public void Close(Window window)
        {
            window?.Close();
        }
    }
}
