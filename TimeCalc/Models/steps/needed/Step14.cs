using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step14 : Step
    {
        public override double MethodicId => 14;
        public override string MethodicName => "Закупка аппаратных и программных средств";

        public override double CalcLabor()
        {
            return T_14_1.FullLabor;
        }

        public override Report CreateReport()
        {
            string html = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом {MethodicId} - {MethodicName}.</p>
<p>Типовые затраты времени на закупку аппаратных и программных средств, а также сборку 
   комплектов аппаратных средств и конструктива автоматизированных рабочих мест рассчитываются согласно следующей таблице:</p>
{T_14_1.ToHtml()}
<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";

            return new Report(25, html);
        }

        public Step14()
        {
            this.WhenAnyValue(x => x.T_14_1)
                .Subscribe((_) => CalcLabor());
        }

        #region DATA

        [Reactive] public Table T_14_1 { get; set; } = new Table(14.1, "Типовые затраты времени на внедрение покупных комплектующих изделий и программных средств в создаваемые изделия",
            new Item("Формирование технических требований к комплектующим изделиям",                                           "1 вид аппаратного средства",  40),
            new Item("Анализ коммерческих предложений и выбор поставщика",                                                     "1 вид аппаратного средства",  44),
            new Item("Оформление закупочной (договорной) документации",                                                        "1 вид аппаратного средства",  40),
            new Item("Проведение входного контроля",                                                                           "1 вид аппаратного средства",  8),
            new Item("Отправка изделий заказчику",                                                                             "1 вид аппаратного средства",  16),
            new Item("Сборка аппаратных средств автоматизированного рабочего места",                                           "1 комплект",                  10),
            new Item("Сборка конструктива для аппаратных средств автоматизированного рабочего места",                          "1 стойка",                    10),
            new Item("Анализ коммерческих предложений и выбор поставщика программных средств",                                 "1 вид программного средства", 4),
            new Item("Оформление закупочной (договорной) документации на приобретение лицензионного программного обеспечения", "1 вид программного средства", 20)
            );
        
        #endregion
    }
}


