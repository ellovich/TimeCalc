using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Templates;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TimeCalc.Views;

namespace TimeCalc
{
    public class Step07 : Step
    {
        public override double MethodicId => 7;
        public override string MethodicName => "Руководство проектом";

        public override double CalcLabor() // TODO &?&?&?&?&?&?
        {
            var steps = new ObservableCollection<Step>(StepsManager.Instance.DoneSteps);
            var steps7 = new List<Step>(steps.Where(s => s.MethodicId == 7));
            if (steps7 != null)
                foreach (var s in steps7)
                    steps.Remove(s);
            return steps.Sum(st => st.Labor) * ((double)Percent / 100);
        }

        public override Report CreateReport()
        {
            string html = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом {MethodicId} - {MethodicName}.</p>
<p>Затраты времени на руководство проектом зависят от сложности проекта и составляют от 5% до 10% от суммарной трудоемкости всех этапов проекта.</p>
<p>Выбранное значение: {Percent}%</p>
<p>Суммарная трудоёмкость без учета руководства: {StepsManager.Instance.FullLabor.Out()}</p>
<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";
            return new Report(53, html);
        }

        public Step07()
        {
            //this.WhenAnyValue(x => x.Percent)
            //    .Subscribe((_) => CalcLabor());
        }

        #region DATA

        [Reactive] public int Percent { get; set; } = 5; // от 5% до 10%

        #endregion
    }
}
