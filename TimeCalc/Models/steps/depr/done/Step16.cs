using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step16 : Step
    {
        public override double MethodicId => 16;
        public override string MethodicName => "Оформление отчётных материалов";

        public override double CalcLabor()
        {
            return T_16_1.FullLabor;
        }

        public override Report CreateReport()
        {
            string html = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом {MethodicId} - {MethodicName}.</p>
<p>Трудозатраты на оформление отчётных материалов по результатам выполнения работ рассчиваются согласно следующей таблице:</p>
{T_16_1.ToHtml()}
<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";

            return new Report(92, html);
        }

        #region ДАННЫЕ

        [Reactive]
        public Table T_16_1 { get; set; } = new Table(16.1, "Нормы времени на оформление отчетных материалов",
            new Item("Создание презентации",                                                         "1 слайд",      7.0 ),
            new Item("Создание демонстрационного видеоролика",                                       "1 видеосцена", 4.5 ),
            new Item("Создание электронного носителя (подготовка файлов к записи, запись носителя)", "1 носитель",   4.4 ),
            new Item("Маркировка электронного носителя",                                             "1 носитель",   2.2 )
        );

        #endregion
    }
}
