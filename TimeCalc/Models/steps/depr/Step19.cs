﻿using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step19 : Step
    {
        public override double MethodicId => 19;
        public override string MethodicName => "Каталогизация";

        public override double CalcLabor()
        {
            return T_19_1.FullLabor;
        }

        public override Report CreateReport()
        {
            string algo = "Трудоемкость вычисляется согласно таблице 19-1.\n";
            algo += T_19_1.ToString();
            return new Report(84, algo);
        }


        #region DATA

        [Reactive] public Table T_19_1 { get; set; }= new Table(19.1, "Нормы времени на проведение работ по каталогизации",
            new Item("Регистрация в системе каталогизации предметов снабжения Вооруженных Сил Российской Федерации", "Количество часов", 1),
            new Item("Составление запроса в центр каталогизации предметов снабжения ВС РФ по закрепленным группам однородной продукции", "Лист А4",          7),
            new Item("Анализ содержания разделов федерального каталога продукции для федеральных государственных нужд (ФКП) с целью определения возможности " +
                     "использования существующих предметов снабжения в составе разрабатываемого изделия", "1 разрабатываемое изделие", 1),
            new Item("Разработка плана мероприятий по каталогизации предметов снабжения, подлежащих включению в ФКП", "1 документ", 1),
            new Item("Разработка проекта номенклатурного перечня предметов снабжения, подлежащих включению в ФКП", "1 документ", 1)
            );

        #endregion
    }
}
