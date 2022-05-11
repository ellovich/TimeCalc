using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Item : ReactiveObject, IEntity
    {
        public int Id => GetHashCode();
        public double MethodicId { get; set; }
        public string Name { get; }
        public string Measure { get; }
        public double Norm { get; }

        [Reactive] public double Quantity { get; set; }
        [Reactive] public Correction Correction { get; set; }

        public double Labor => Quantity * Norm * Correction.Coef;

        /// <summary>
        /// Пункт таблицы.
        /// </summary>
        /// <param name="name">Название пункта.</param>
        /// <param name="measure">Единица измерения.</param>
        /// <param name="norm">Норма.</param>
        public Item(string name, string measure, double norm)
        {
            Name = name;
            Measure = measure;
            Norm = norm;
            Correction = new Correction("None", 1);

            this.WhenAnyValue(
                x => x.Quantity,
                x => x.Correction);
        }

        public string ToHtml()
        {
            return $@"
<tr>
    <td>{Name}</td>
    <td>{Measure}</td>
    <td>{Norm}</td>
    <td>{Correction.Coef}</td>
    <td>{Quantity}</td>
    <td>{Labor.Out()}</td>
</tr>
" + "\n";
        }

        public override string ToString()
        {
            return $"{Name}: {Quantity} ({Measure}) шт. x {Norm} ч x {Correction.Coef} ({Correction.Name} ст.кор.) = {Labor.Out()} ч/ч;";
        }
    }

    public class Table : IEntity
    {
        public int Id => GetHashCode();
        public double MethodicId { get; }
        public string Name { get; set; }
        [Reactive] public ObservableCollection<Item> TableItems { get; set; }
        private bool _custom;

        /// <summary>
        /// Конструктор для таблицы.
        /// </summary>
        /// <param name="name">Название таблицы в методички</param>
        /// <param name="tableItems">Пункты таблицы</param>
        public Table(string name, params Item[] tableItems)
        {
            _custom = true;

            Name = name;
            TableItems = new ObservableCollection<Item>(tableItems);
            for (int i = 0; i < TableItems.Count; i++)
            {
                TableItems[i].MethodicId = i + 1;
            }

            //this.WhenAnyObservable(x => TableItems.ToObservableChangeSet(x => x));

            // this.WhenAnyValue(x => x.TableItems).Subscribe((_) => Debug.WriteLine($"TABLE {DateTime.Now}"));
        }

        /// <summary>
        /// Конструктор для таблицы из методички.
        /// </summary>
        /// <param name="methodicId">Номер этапа в методичке</param>
        /// <param name="name">Название таблицы в методички</param>
        /// <param name="tableItems">Пункты таблицы</param>
        public Table(double methodicId, string name, params Item[] tableItems)
        {
            MethodicId = methodicId;
            Name = name;
            TableItems = new ObservableCollection<Item>(tableItems);
            for (int i = 0; i < TableItems.Count; i++)
            {
                TableItems[i].MethodicId = i + 1;
            }

            //this.WhenAnyValue(x => x.TableItems);


            //var t = TableItems.ToObservableChangeSet(x => x);
            //this.WhenAnyObservable(
            //    x => t)
            //    .Subscribe((_) => Debug.WriteLine("!"));
        }

        public Item[] SelectedItems => TableItems.Where(item => item.Quantity != 0).ToArray();

        public double FullLabor => SelectedItems.Sum(item => item.Labor);

        public void AddItem(Item item) => TableItems.Add(item);
        public void RemoveItem(Item item) => TableItems.Remove(item);

        public string ToHtml()
        {
            var caption = _custom ? $"{Name}" : $"{MethodicId.ToString().Replace(',', '-')}. {Name}";

            return $@"
<table>
    <caption>{caption}</caption>
    <tr>
        <th>Название</th>
        <th style=""width:15%"">Единица измерения</th>
        <th style=""width:10%"">Норма</th>
        <th style=""width:10%"">Коэффициент</th>
        <th style=""width:10%"">Количество</th>
        <th style=""width:10%"">Трудоёмкость</th>
    </tr>
    {string.Join("\n", SelectedItems.Select(i => i.ToHtml()))}
</table>
" + "\n";
        }

        public override string ToString()
        {
            string str = $"!!! { Name }\n";

            foreach (var пункт in TableItems)
                str += пункт + "\n";
            str += $" --> Итого: { FullLabor.Out() }\n";

            return str;
        }
    }
}
