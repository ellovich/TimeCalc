using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step12 : Step
    {
        public override double MethodicId => 12;
        public override string MethodicName => "Проведение испытаний";

        public override double CalcLabor()
        {
            return (K * T) + AddedTables.Sum(t => t.FullLabor);
        }

        public override Report CreateReport()
        {
            string algo = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом {MethodicId} - {MethodicName}.</p>
<p>
    Нормы времени на проведение испытаний рассчитываются по формуле 49: T<sub>об</sub> = k * t + T<sub>д</sub>
    <br>
    k = { K } - количество сотрудников, принимающих участие в проведении испытаний; </br>
    t = { T } - длительность испытаний; </br>
    Т<sub>д</sub> = { AddedTables.Sum(t => t.FullLabor) } - трудоёмкость изготовления и выпуска перечисленных документов:
</p>
    {string.Join("\n", AddedTables.Select(t => t.ToHtml()))}
<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";

            return new Report(25, algo);
        }

        public Step12()
        {
            this.WhenAnyValue(
                x => x.K,
                x => x.T).Subscribe((_) => CalcLabor());

            // AddedTables
        }


        #region DATA

        [Reactive] public int K { get; set; }      // количество сотрудников, принимающих участие в проведении испытаний
        [Reactive] public double T { get; set; }   // длительность испытаний (ч)

        [Reactive] public ObservableCollection<Table> AddedTables { get; set; } = new ObservableCollection<Table>();
        public static List<Table> ReadySteps { get; set; } = Step02.ReadyStepsTables;
        public static List<Table> SingleSteps { get; set; } = Step02.SingleStepsTables;

        public static readonly List<Correction> s_Corrections_2_9 = Step02.s_Corrections2_9;

        #endregion
    }
}
