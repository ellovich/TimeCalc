using System;
using System.Collections.Generic;
using System.Diagnostics;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step06 : Step
    {
        public override double MethodicId => 6;
        public override string MethodicName => "Формирование электронной технической библиотеки " +
                                               "интерактивных руководящих, эксплуатационных и учебно-методических документов";

        public override double CalcLabor()
        {
            return (_T_ит + _T_рт + _T_чс + _T_п) * Correction.Coef;
        }

        public override Report CreateReport()
        {
            string html = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом {MethodicId} - {MethodicName}.</p>
<p>
   n<sub>ЛТ  </sub>   Количество листов текста: {N_лт} <br>
   n<sub>Рис </sub>   Количество рисунков: {N_рис} <br>
   n<sub>ЛТаб</sub>   Количество листов таблиц: {N_лтаб} <br>
   n<sub>ЧС  </sub>   Количество чертежей (схем): {N_чс} <br>
   n<sub>Д   </sub>   Количество документов: {N_д} <br>
   k<sub>Нов </sub>   Степень корректировки: {Correction} <br>
</p>
<p>
   Общая трудоёмкость формирования электронной технической библиотеки определяется по формуле 21: <br>
   T<sub>библ</sub> = Т<sub>ИТ</sub> + Т<sub>РТ</sub> + Т<sub>ЧС</sub> + Т<sub>П</sub> <br>
   <br>
   Т<sub>ИТ</sub> = {_T_ит.Out()} - трудоёмкость создания интерактивных документов; <br>
   Т<sub>РТ</sub> = {_T_рт.Out()} - трудоёмкость создания рисунков и таблиц; <br>
   Т<sub>ЧС</sub> = {_T_чс.Out()} - трудоёмкость создания чертежей и схем; <br>
   Т<sub>П</sub> = {_T_п.Out()} - трудоёмкость размещения файлов в каталогах программы и внесения в оглавление библиотеки документации; <br>
</p>
<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";

            return new Report(50, html);
        }

        public Step06()
        {
            this.WhenAnyValue(
                x => x.N_д,
                x => x.N_рис,
                x => x.N_лтаб,
                x => x.N_чс,
                x => x.N_д,
                x => x.Correction).Subscribe((_) => CalcLabor());
        }


        #region DATA

        [Reactive] public int N_лт { get; set; }   // количество листов текста
        [Reactive] public int N_рис { get; set; }  // количество рисунков
        [Reactive] public int N_лтаб { get; set; } // количество листов таблиц
        [Reactive] public int N_чс { get; set; }   // количество чертежей (схем)
        [Reactive] public int N_д { get; set; }    // количество документов
        [Reactive] public Correction Correction { get; set; }


        
        private double _T_ит => N_лт * (_q_скан + _q_ред_т + _q_html);                               // (ф.22, п.6.1.2, с.51) // интерактивный текст 
        private double _T_рт => N_рис * _q_ред_р + N_лтаб * _q_ред_таб + _q_html * (N_рис + N_лтаб); // (ф.23, п.6.1.3, с.51) // рисунки и таблицы 
        private double _T_чс => N_чс * (_q_чс + _q_html);                                            // (ф.24, п.6.1.4, с.52) // чертежи и схема  
        private double _T_п => N_д * _q_п; // ф.25, п.6.1.5, с.52 // размещение файлов в каталогах программы и внесение в оглавление библиотеки документации 

        // т.6-1 (с.51)
        private const double _q_скан = 0.2;    // скнирование и распознавание текста (1 лист)
        private const double _q_ред_т = 0.25;  // редактирование распознанного текста (1 лист)
        private const double _q_ред_р = 4.0;   // редактирование сканированного рисунка (1 рисунок)
        private const double _q_ред_таб = 0.5; // редактирование сканированной таблицы (1 лист)
        private const double _q_чс = 5.0;      // подготовка чертежа (1 чертеж/схема)
        private const double _q_html = 1.0;    // перевод материалов в HTML-документ (1 лист)
        private const double _q_п = 0.2;       // чертеж детали (1 документ)

        public static readonly List<Correction> s_Corrections_6_2 = new List<Correction>()
        {
            new Correction("Полная разработка", 1),
            new Correction("Очень высокая", 0.85),
            new Correction("Высокая", 0.7),
            new Correction("Средняя", 0.5),
            new Correction("Низкая", 0.3),
            new Correction("Очень низкая", 0.15),
        };

        #endregion
    }
}
