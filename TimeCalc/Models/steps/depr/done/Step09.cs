using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step09 : Step
    {
        public override double MethodicId => 9;
        public override string MethodicName => "Математическое моделирование";

        public override double CalcLabor()
        {
            return (Комплексирование) ?
                T_9_1.FullLabor * 1.3 : // + (0,3 трудоемкости разработки входящих в нее мат. моделей)
                T_9_1.FullLabor;
        }

        public override Report CreateReport()
        {
            string html = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом {MethodicId} - {MethodicName}.</p>
<p>Нормы времени на математическое моделирование определяются по следующей таблице:</p>
{T_9_1.ToHtml()}

{(Комплексирование ? 
$@"
    Вследствие комплексирования мат. моделей отдельных элементов
    в математическую модель агрегата (установки), к сумме трудоемкостей
    ({ T_9_1.FullLabor }ч) прибавляется 0,3 трудоемкости разработки
    входящих в нее мат. моделей (+{ T_9_1.FullLabor * 0.3 }ч).
" : "")}

<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";

            return new Report(66, html);
        }


        #region ДАННЫЕ

        [Reactive] public Table T_9_1 { get; set; } = new Table(9.1, "Нормы времени на математическое моделирование моделирование",
            new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 50",   "1 модель", 180 ),
            new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 100",  "1 модель", 350 ),
            new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 250",  "1 модель", 800 ),
            new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 500",  "1 модель", 1700),
            new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 1000", "1 модель", 3000)
            );

        [Reactive] public bool Комплексирование { get; set; }

        public static readonly List<Correction> s_Corrections9_2 = new List<Correction>()
        {
            new Correction("Малая",                            0.3 ),
            new Correction("Средняя",                          0.5 ),
            new Correction("Значительная",                     0.7 ),
            new Correction("Приминение нового метода решения", 0.8 ),
        };

        #endregion
    }
}
