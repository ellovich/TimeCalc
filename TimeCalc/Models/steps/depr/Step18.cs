using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step18 : Step
    {
        public override double MethodicId => 18;
        public override string MethodicName => "Оформление отчётных материалов";

        public override double CalcLabor()
        {
            return T_18_1.FullLabor;
        }

        public override Report CreateReport()
        {
            string algo = "Трудоемкость вычисляется согласно таблице 18-1.\n";
            algo += T_18_1.ToString();
            return new Report(83, algo);
        }

        #region ДАННЫЕ

        [Reactive] public Table T_18_1 { get; set; } = new Table(18.1, "Нормы времени на оформление отчетных материалов",
            new Item("Создание презентации", "1 слайд", 7.0),
            new Item("Создание демонстрационного видеоролика", "1 видеосцена", 4.5),
            new Item("Создание электронного носителя (подготовка файлов к записи, запись носителя)", "1 носитель", 4.4),
            new Item("Маркировка электронного носителя", "1 носитель", 2.2)
        );

        #endregion
    }
}
