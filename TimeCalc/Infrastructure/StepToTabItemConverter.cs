using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using TimeCalc.ViewModels;
using TimeCalc.Views;

namespace TimeCalc
{
    internal class StepToTabItemConverter// : IValueConverter
    {
        public static ObservableCollection<TabItem> Convert(Collection<Step> steps)
        {
            var tabItems = new ObservableCollection<TabItem>();

            foreach (var step in steps)
                tabItems.Add(Convert(step));

            return tabItems;
        }


        //public static TabItem Convert(ViewModelBase vm, string name)
        //{
        //    return new TabItem()
        //    {
        //        Header = name,
        //        Content = new StepsManagerPage(),
        //    };
        //}
        

        public static TabItem Convert(Step step)
        {
            if (!(step is Step))
                return null;

            return new TabItem()
            {
                Header = /* step.MethodicId + ". " + */ step.Name,
                Content = StepViewModel.CreateView(step),
            };
        }


        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (!(value is Step step)) 
        //        return null;

        //    return new TabItem() {
        //        Header = step.Name,
        //        Content = StepViewModel.CreateViewModel(step),
        //    };
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
