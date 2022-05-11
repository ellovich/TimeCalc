using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step03 : Step
    {
        public override double MethodicId => 3;
        public override string MethodicName => "Формирование информационных массивов (ИМ) специального программного обеспечения (СПО) СИП БЖ";

        public override double CalcLabor()
        {
            return _T_ИМ +
                _T_прот + _T_кк + _T_ср + _T_ос;
        }

        private string RowHtmlCreator(int i, string T_name, string formula, double val, params string[] vars)
        {
            return $@"
<tr>
    <td text-align=""center"">
        t<sub>{i}</sub>
    </td>
    <td>
        {T_name}
    </td>
    <td>
        <tt>
        t<sub>{i}</sub> = {formula}
        </tt>
    </td>
    <td>
        <tt>
            { string.Join("<br>", vars) }
        </tt>
    </td>
    <td text-align=""center"">
        {val.Out()}
    </td>
</tr>
";
        }

        public override Report CreateReport()
        {
            #region ROWS

            // t.3-2
            string rowT1 = RowHtmlCreator(1, T1, "q<sub>пш</sub> ⋅ n<sub>пш</sub> ⋅ k<sub>1</sub> ⋅ k<sub>нов</sub>", _t1, new string[] {
                $"q<sub>пш</sub> = {_q_пш.Out()}",
                $"n<sub>пш</sub> = {N_пш}",
                $"k<sub>1</sub> = {K1.Coef.Out()}",
                $"k<sub>нов</sub> = {K_нов_1.Coef.Out()}" });
            string rowT2 = RowHtmlCreator(2, T2, "(t<sub>1</sub> ⋅ k<sub>2</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t2, new string[] {
                $"t<sub>1</sub> = {_t1.Out()}",
                $"k<sub>2</sub> = {_k2.Out()}",
                $"k<sub>нов</sub> = {K_нов_2.Coef.Out()}",
                $"k<sub>1</sub> = {K1.Coef.Out()}" });
            string rowT3 = RowHtmlCreator(3, T3, "(t<sub>1</sub> ⋅ k<sub>3</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t3, new string[] {
                $"t<sub>1</sub> = {_t1.Out()}",
                $"k<sub>3</sub> = {K3.Coef.Out()}",
                $"k<sub>нов</sub> = {K_нов_3.Coef.Out()}",
                $"k<sub>1</sub> = {K1.Coef.Out()}" });
            string rowT4 = RowHtmlCreator(4, T4, "(t<sub>1</sub> ⋅ k<sub>4</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t4, new string[] {
                $"t<sub>1</sub> = {_t1.Out()}",
                $"k<sub>4</sub> = {_k4.Out()}",
                $"k<sub>нов</sub> = {K_нов_4.Coef.Out()}",
                $"k<sub>1</sub> = {K1.Coef.Out()}" });
            string rowT5 = RowHtmlCreator(5, T5, "(t<sub>1</sub> ⋅ k<sub>5</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t5, new string[] {
                $"t<sub>1</sub> = {_t1.Out()}",
                $"k<sub>5</sub> = {_k5.Out()}",
                $"k<sub>нов</sub> = {K_нов_5.Coef.Out()}",
                $"k<sub>1</sub> = {K1.Coef.Out()}" });
            string rowT6 = RowHtmlCreator(6, T6, "(t<sub>1</sub> ⋅ k<sub>6</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t6, new string[] {
                $"t<sub>1</sub> = {_t1.Out()}",
                $"k<sub>6</sub> = {_k6.Out()}",
                $"k<sub>нов</sub> = {K_нов_6.Coef.Out()}",
                $"k<sub>1</sub> = {K1.Coef.Out()}" });
            string rowT7 = RowHtmlCreator(7, T7, "(t<sub>1</sub> ⋅ k<sub>7</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t7, new string[] {
                $"t<sub>1</sub> = {_t1.Out()}",
                $"k<sub>7</sub> = {K7.Coef.Out()}",
                $"k<sub>нов</sub> = {K_нов_7.Coef.Out()}",
                $"k<sub>1</sub> = {K1.Coef.Out()}" });

            // t.3-3
            string rowT8 = RowHtmlCreator(8, T8, "q<sub>ВО</sub> ⋅ n<sub>ВО</sub> ⋅ k<sub>8</sub> ⋅ k<sub>нов</sub>", _t8, new string[] {
                $"q<sub>ВО</sub> = {_q_ВО.Out()}",
                $"n<sub>ВО</sub> = {N_ВО}",
                $"k<sub>8</sub> = {K8.Coef.Out()}",
                $"k<sub>нов</sub> = {K_нов_8.Coef.Out()}" });
            string rowT9 = RowHtmlCreator(9, T9, "t<sub>8</sub> ⋅ k<sub>9</sub> ⋅ k<sub>нов</sub>", _t9, new string[] {
                $"t<sub>8</sub> = {_t8.Out()}",
                $"k<sub>9</sub> = {_k9.Out()}",
                $"k<sub>нов</sub> = {K_нов_9.Coef.Out()}" });
            string rowT10 = RowHtmlCreator(10, T10, "t<sub>8</sub> ⋅ k<sub>10</sub> ⋅ k<sub>нов</sub>", _t10, new string[] {
                $"t<sub>8</sub> = {_t8.Out()}",
                $"k<sub>10</sub> = {K10.Coef.Out()}",
                $"k<sub>нов</sub> = {K_нов_10.Coef.Out()}" });

            // t.3-5
            string rowT11 = RowHtmlCreator(11, T11, "q<sub>пом</sub> ⋅ n<sub>пом</sub> ⋅ k<sub>11</sub> ⋅ k<sub>нов</sub>", _t11, new string[] {
                $"q<sub>пом</sub> = {_q_пом.Out()}",
                $"n<sub>пом</sub> = {N_пом}",
                $"k<sub>11</sub> = {_k11.Out()}",
                $"k<sub>нов</sub> = {K_нов_11.Coef.Out()}" });
            string rowT12 = RowHtmlCreator(12, T12, "q<sub>АУ</sub> ⋅ n<sub>АУ</sub> ⋅ n<sub>пал</sub> ⋅ k<sub>12</sub> ⋅ k<sub>нов</sub>", _t12, new string[] {
                $"q<sub>АУ</sub> = {_q_АУ.Out()}",
                $"n<sub>АУ</sub> = {N_АУ}",
                $"n<sub>пал</sub> = {N_пал}",
                $"k<sub>12</sub> = {_k12.Out()}",
                $"k<sub>нов</sub> = {K_нов_12.Coef.Out()}" });
            string rowT13 = RowHtmlCreator(13, T13, "(t<sub>11</sub> ⋅ k<sub>13</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t13, new string[] {
                $"t<sub>11</sub> = {_t11.Out()}",
                $"k<sub>13</sub> = {_k13.Out()}",
                $"k<sub>нов</sub> = {K_нов_13.Coef.Out()}",
                $"k<sub>11</sub> = {_k11.Out()}" });
            string rowT14 = RowHtmlCreator(14, T14, "(t<sub>11</sub> ⋅ k<sub>14</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t14, new string[] {
                $"t<sub>11</sub> = {_t11.Out()}",
                $"k<sub>14</sub> = {_k14.Out()}",
                $"k<sub>нов</sub> = {K_нов_14.Coef.Out()}",
                $"k<sub>11</sub> = {_k11.Out()}" });
            string rowT15 = RowHtmlCreator(15, T15, "(t<sub>11</sub> ⋅ k<sub>15</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t15, new string[] {
                $"t<sub>11</sub> = {_t11.Out()}",
                $"k<sub>15</sub> = {_k15.Out()}",
                $"k<sub>нов</sub> = {K_нов_15.Coef.Out()}",
                $"k<sub>11</sub> = {_k11.Out()}" });
            string rowT16 = RowHtmlCreator(16, T16, "(t<sub>11</sub> ⋅ k<sub>16</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t16, new string[] {
                $"t<sub>11</sub> = {_t11.Out()}",
                $"k<sub>16</sub> = {_k16.Out()}",
                $"k<sub>нов</sub> = {K_нов_16.Coef.Out()}",
                $"k<sub>11</sub> = {_k11.Out()}" });
            string rowT17 = RowHtmlCreator(17, T17, "(t<sub>12</sub> ⋅ k<sub>17</sub> ⋅ k<sub>нов</sub>) / k<sub>12</sub>", _t17, new string[] {
                $"t<sub>12</sub> = {_t12.Out()}",
                $"k<sub>17</sub> = {_k13.Out()}",
                $"k<sub>нов</sub> = {K_нов_17.Coef.Out()}",
                $"k<sub>12</sub> = {_k12.Out()}" });
            string rowT18 = RowHtmlCreator(18, T18, "(t<sub>11</sub> ⋅ k<sub>18</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t18, new string[] {
                $"t<sub>11</sub> = {_t11.Out()}",
                $"k<sub>18</sub> = {_k18.Out()}",
                $"k<sub>нов</sub> = {K_нов_18.Coef.Out()}",
                $"k<sub>11</sub> = {_k11.Out()}" });
            string rowT19 = RowHtmlCreator(19, T19, "q<sub>ОКС</sub> ⋅ n<sub>ОКС</sub> ⋅ k<sub>19</sub> ⋅ k<sub>нов</sub>", _t19, new string[] {
                $"q<sub>ОКС</sub> = {_q_ОКС.Out()}",
                $"n<sub>ОКС</sub> = {N_ОКС}",
                $"k<sub>19</sub> = {_k19.Out()}",
                $"k<sub>нов</sub> = {K_нов_19.Coef.Out()}" });
            string rowT20 = RowHtmlCreator(20, T20, "(t<sub>19</sub> ⋅ k<sub>20</sub> ⋅ k<sub>нов</sub>) / k<sub>19</sub>", _t20, new string[] {
                $"t<sub>19</sub> = {_t19.Out()}",
                $"k<sub>20</sub> = {_k20.Out()}",
                $"k<sub>нов</sub> = {K_нов_20.Coef.Out()}",
                $"k<sub>19</sub> = {_k19.Out()}" });
            string rowT21 = RowHtmlCreator(21, T21, "(t<sub>11</sub> ⋅ k<sub>21</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t21, new string[] {
                $"t<sub>11</sub> = {_t11.Out()}",
                $"k<sub>21</sub> = {_k21.Out()}",
                $"k<sub>нов</sub> = {K_нов_21.Coef.Out()}",
                $"k<sub>11</sub> = {_k11.Out()}" });
            string rowT22 = RowHtmlCreator(22, T22, "(t<sub>11</sub> ⋅ k<sub>22</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t22, new string[] {
                $"t<sub>11</sub> = {_t11.Out()}",
                $"k<sub>22</sub> = {_k22.Out()}",
                $"k<sub>нов</sub> = {K_нов_22.Coef.Out()}",
                $"k<sub>11</sub> = {_k11.Out()}" });
            string rowT23 = RowHtmlCreator(23, T23, "(t<sub>19</sub> ⋅ k<sub>23</sub> ⋅ k<sub>нов</sub>) / k<sub>19</sub>", _t23, new string[] {
                $"t<sub>19</sub> = {_t19.Out()}",
                $"k<sub>23</sub> = {_k23.Out()}",
                $"k<sub>нов</sub> = {K_нов_23.Coef.Out()}",
                $"k<sub>19</sub> = {_k19.Out()}" });
            string rowT24 = RowHtmlCreator(24, T24, "(t<sub>12</sub> ⋅ k<sub>24</sub> ⋅ k<sub>нов</sub>) / k<sub>12</sub>", _t24, new string[] {
                $"t<sub>12</sub> = {_t12.Out()}",
                $"k<sub>24</sub> = {_k24.Out()}",
                $"k<sub>нов</sub> = {K_нов_24.Coef.Out()}",
                $"k<sub>12</sub> = {_k12.Out()}" });
            string rowT25 = RowHtmlCreator(25, T25, "q<sub>АК</sub> ⋅ n<sub>АК</sub> ⋅ k<sub>25</sub> ⋅ k<sub>нов</sub>", _t25, new string[] {
                $"q<sub>АК</sub> = {_q_АК.Out()}",
                $"n<sub>АК</sub> = {N_АК}",
                $"k<sub>25</sub> = {_k25.Out()}",
                $"k<sub>нов</sub> = {K_нов_25.Coef.Out()}" });

            #endregion


            string html = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом 3 - {MethodicName}.</p>

Общая трудоёмкость формирования ИМ СПО СИП БЖ (T<sub>ИМ</sub>) определяется по формуле:
T<sub>ИМ</sub> = T<sub>Н</sub> + T<sub>БЖ</sub> <br>
где<br>
T<sub>Н</sub> = {_T_Н} - трудоёмкость формирования (корректировки) ИМ задач непотопляемости <br>
T<sub>БЖ</sub> = {_T_БЖ} - трудоёмкость формирования (корректировки) ИМ задач борьбы с пожаром и водой. Определяется суммой трудоёмкостей работ таблицы 3-5 <br>
<br>

{(IsT_К && IsT_ВО ? 
$@"
T<sub>Н</sub> = T<sub>К</sub> + T<sub>ВО</sub> <br>
где <br>
T<sub>К</sub> = {_T_K} - трудоёмкости заполнения (корректировки) ИМ задач непотопляемости в части данных по кораблю/судну в целом. Определяется суммой трудоёмкостей работ таблицы 3-2<br>
T<sub>ВО</sub> = {_T_ВО} - трудоёкости формирования (корректировки) ИМ задач непотопляемости в части данных по ВО корпуса, включая газоплотные отделения надстройки корабля/судна. Определяется суммой трудоёмкостей работ таблицы 3-3 <br>
" : "")}

{(IsT_К ?
$@"
<table>
    <caption>т.3-2 Определение трудоёмкости работ по формированию (корректировке) ИМ в части данных по кораблю (судну) в целом</caption>
    <tr>
        <th style=""width:3%"">t<sub>i</sub></th>
        <th>Наименование работы</th>
        <th style=""width:25%"">Формула</th>
        <th style=""width:10%"">Значения</th>
        <th style=""width:10%"">Трудоёмкость</th>
    </tr>
    {(IsT1 ? rowT1 : " ")}
    {(IsT2 ? rowT2 : " ")}
    {(IsT3 ? rowT3 : " ")}
    {(IsT4 ? rowT4 : " ")}
    {(IsT5 ? rowT5 : " ")}
    {(IsT6 ? rowT6 : " ")}
    {(IsT7 ? rowT7 : " ")}  
</table>
" : "")}

{(IsT_ВО ?
$@"
<table>
    <caption>т.3-3 Трудоёмкость работ по заполнению (корректировке) ИМ в части данных по ВО корпуса</caption>
    <tr>
        <th style=""width:5%"">t<sub>i</sub></th>
        <th>Наименование работы</th>
        <th style=""width:25%"">Формула</th>
        <th style=""width:10%"">Значения</th>
        <th style=""width:10%"">Трудоёмкость</th>
    </tr>
    {(IsT8 ? rowT8 : " ")}
    {(IsT9 ? rowT9 : " ")}
    {(IsT10 ? rowT10 : " ")}    
</table>
" : "")}

{(IsT_БЖ ?
$@"
<table>
    <caption>т.3-5 Порядок определения трудоёмкости заполнения ИМ в части данных задач борьбы с пожаром и водой</caption>
    <tr>
        <th style=""width:5%"">t<sub>i</sub></th>
        <th>Наименование работы</th>
        <th style=""width:25%"">Формула</th>
        <th style=""width:10%"">Значения</th>
        <th style=""width:10%"">Трудоёмкость</th>
    </tr>
    {(IsT11 ? rowT11 : " ")}
    {(IsT12 ? rowT12 : " ")}
    {(IsT13 ? rowT13 : " ")}
    {(IsT14 ? rowT14 : " ")}
    {(IsT15 ? rowT15 : " ")}
    {(IsT16 ? rowT16 : " ")}
    {(IsT17 ? rowT17 : " ")}  
    {(IsT18 ? rowT18 : " ")}  
    {(IsT19 ? rowT19 : " ")}  
    {(IsT20 ? rowT20 : " ")}  
    {(IsT21 ? rowT21 : " ")}  
    {(IsT22 ? rowT22 : " ")}  
    {(IsT23 ? rowT23 : " ")}  
    {(IsT24 ? rowT24 : " ")}  
    {(IsT25 ? rowT25 : " ")}  
</table>
" : "")}

{(IsT_прот ? 
$@"
Трудоёмкость разработки протокола сопряжения с внешними (по отношению к СПО СИП БЖ) системами комплексами корабля/судна составляет 56 нормо-часов на один протокол <br>
n<sub>прот</sub> = {N_прот} - количество протоколов сопряжения <br>
<br>
T<sub>прот</sub> = n<sub>прот</sub> ⋅ 56 = {_T_прот}
" : "")}

{(IsT_кк ?
$@"
<p>
    Трудоёмкость корректировки ИМ СПО по результатам кренования корабля/судна и тарирорвки (проливки) цистерн: <br>
    T<sub>кк</sub> = t<sub>5</sub> + t<sub>9</sub> + t<sub>10</sub> = {_T_кк.Out()} <br>
    <br>
    t<sub>5</sub> = {_t5.Out()} <br>
    t<sub>9</sub> = {_t9.Out()} <br>
    t<sub>10</sub> = {_t10.Out()} <br>
</p>
" : "")}

{(IsT_ср ?
$@"
<p>
    Трудоёмкость сравнительных расчётов посадки и остойчивости: <br>
    T<sub>ср</sub> = n<sub>ср</sub> ⋅ q<sub>ср</sub> = {_T_кк.Out()} <br>
    <br>
    n<sub>ср</sub> = {N_ср} <br>
    q<sub>ср</sub> = {_q_ср.Out()} <br>
</p>
"
: "")}

<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";

            return new Report(36, html);
        }

        public Step03()
        {
            this.WhenAnyValue(
                x => x.N_пш,
                x => x.N_ВО,
                x => x.N_пал,
                // x => x.N_вч,
                x => x.N_пом,
                x => x.N_АУ,
                x => x.N_АК,
                x => x.N_ОКС).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K1,
                x => x.K3,
                x => x.K7,
                x => x.K8,
                x => x.K10).Subscribe((_) => CalcLabor());


            #region K_нов_?

            this.WhenAnyValue(
                x => x.K_нов_1,
                x => x.K_нов_2,
                x => x.K_нов_3,
                x => x.K_нов_4,
                x => x.K_нов_5,
                x => x.K_нов_6,
                x => x.K_нов_7).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K_нов_8,
                x => x.K_нов_9,
                x => x.K_нов_10,
                x => x.K_нов_11,
                x => x.K_нов_12,
                x => x.K_нов_13,
                x => x.K_нов_14).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K_нов_15,
                x => x.K_нов_16,
                x => x.K_нов_17,
                x => x.K_нов_18,
                x => x.K_нов_19,
                x => x.K_нов_20,
                x => x.K_нов_21).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K_нов_22,
                x => x.K_нов_23,
                x => x.K_нов_24,
                x => x.K_нов_25).Subscribe((_) => CalcLabor());

            #endregion


            #region IsT?

            this.WhenAnyValue(
                x => x.IsT_К,
                x => x.IsT_ВО,
                x => x.IsT_БЖ
                //,
                //x => x.IsT_прот,
                //x => x.IsT_кк,
                //x => x.IsT_ос
                ).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.IsT1,
                x => x.IsT2,
                x => x.IsT3,
                x => x.IsT4,
                x => x.IsT5,
                x => x.IsT6,
                x => x.IsT7).Subscribe((_) => CalcLabor());
            this.WhenAnyValue(
                x => x.IsT8,
                x => x.IsT9,
                x => x.IsT10,
                x => x.IsT11,
                x => x.IsT12,
                x => x.IsT13,
                x => x.IsT14).Subscribe((_) => CalcLabor());
            this.WhenAnyValue(
                x => x.IsT15,
                x => x.IsT16,
                x => x.IsT17,
                x => x.IsT18,
                x => x.IsT19,
                x => x.IsT20,
                x => x.IsT21).Subscribe((_) => CalcLabor());
            this.WhenAnyValue(
                x => x.IsT22,
                x => x.IsT23,
                x => x.IsT24,
                x => x.IsT25).Subscribe((_) => CalcLabor());

            #endregion


            #region 3.6 - 3.9

            this.WhenAnyValue(
                x => x.N_прот,
                x => x.N_ср).Subscribe((_) => CalcLabor());

            // Отладки changed

            #endregion
        }


        #region DATA

        [Reactive] public int N_пш { get; set; }  // количество практических шпангоутов
        [Reactive] public int N_ВО { get; set; }  // количество ВО судна, включая газоплотные отделения надстройки
        [Reactive] public int N_пал { get; set; } // количество палуб,платформ и ярусов надстройки
        // [Reactive] public int N_вч { get; set; } // количество выступающих частей
        [Reactive] public int N_пом { get; set; }  // количество помещений
        [Reactive] public int N_АУ { get; set; }   // количество АУ (аварийных участков)
        [Reactive] public int N_АК { get; set; }   // количество практических шпангоутов
        [Reactive] public int N_ОКС { get; set; }  // количество ОКС (общекораб. систем), исп. в СПО СИП БЖ для задач инф. поддержки

        private double _T_ИМ => _T_Н + _T_БЖ; // (7) общая трудоёмкость формирования ИМ СПО СИП


        #region НЕПОТОПЛЯЕМОСТЬ _T_Н

        private double _T_Н => _T_K + _T_ВО; // (8) трудоёмкость формирования ИМ задач непотопляемости
        private double _T_K => _t1 + _t2 + _t3 + _t4 + _t5 + _t6 + _t7; // трудоёмкость ввода данных по кораблю в целом
        private double _T_ВО => _t8 + _t9 + _t10; // трудоёмкость ввода (проверки и корректировки) данных по ВО корпуса


        private bool _isT_К = true;
        public bool IsT_К // Reactive
        {
            get => _isT_К;
            set
            {
                IsT1 = IsT2 = IsT3 = IsT4 = IsT5 = IsT6 = IsT7 = value;
                this.RaiseAndSetIfChanged(ref _isT_К, value);
            }
        }


        private bool _isT_ВО = true;
        public bool IsT_ВО // Reactive
        {
            get => _isT_ВО;
            set
            {
                IsT8 = IsT9 = IsT10 = value;
                this.RaiseAndSetIfChanged(ref _isT_ВО, value);
            }
        }


        #region _ti

        // t.3-2
        #region t1
        public static string T1 = "Ввод геометрии теоретической поверхности корпуса";
        private double _t1 => IsT1 ? 0 : _q_пш * N_пш * K1.Coef * K_нов_1.Coef;
        private const double _q_пш = 1.6;
        [Reactive] public Correction K1 { get; set; }
        public static List<Correction> s_Corrections3_4_1 = new List<Correction>()
        {
            new Correction("Традиционные обводы корпуса", 1),
            new Correction("Сложные обводы носовой и кормовой оконечности", 1.2)
        }; // k_1 Cложность геометрии обводов корпуса
        [Reactive] public Correction K_нов_1 { get; set; }
        [Reactive] public bool IsT1 { get; set; } = true;
        #endregion

        #region t2
        public static string T2 = "Ввод геометрии палуб, платформ, ярусов надстроек и др.";
        private double _t2 => IsT2 ? 0 : _t1 * _k2 * K_нов_2.Coef / K1.Coef;
        private double _k2 => N_пал < 6 ? 1.8 : 1.8 + 0.1 * (N_пал - 5); // выбор делается автоматически
        [Reactive] public Correction K_нов_2 { get; set; }
        [Reactive] public bool IsT2 { get; set; } = true;
        #endregion

        // TODO t3 сделать автоматический выбор коэффициента
        #region t3 
        public static string T3 = "Ввод геометрии выступающих частей";
        private double _t3 => IsT3 ? 0 : _t1 * K3.Coef * K_нов_3.Coef / K1.Coef;
        [Reactive] public Correction K3 { get; set; }
        public static List<Correction> s_Corrections3_4_3 = new List<Correction>()
        {
            new Correction("3 и менее", 1),
            new Correction("Более 3", 1.1)
        }; // k_3 Количество выступающих частей 
        [Reactive] public Correction K_нов_3 { get; set; }
        [Reactive] public bool IsT3 { get; set; } = true;
        #endregion

        #region t4
        public static string T4 = "Ввод геометрии зон обледенения";
        private double _t4 => IsT4 ? 0 : _t1 * _k4 * K_нов_4.Coef / K1.Coef;
        private const double _k4 = 3.0;
        [Reactive] public Correction K_нов_4 { get; set; }
        [Reactive] public bool IsT4 { get; set; } = true;
        #endregion

        #region t5
        public static string T5 = "Ввод постоянных данных по кораблю";
        private double _t5 => IsT5 ? 0 : _t1 * _k5 * K_нов_5.Coef / K1.Coef;
        private const double _k5 = 2.2;
        [Reactive] public Correction K_нов_5 { get; set; }
        [Reactive] public bool IsT5 { get; set; } = true;
        #endregion

        #region t6
        public static string T6 = "Ввод данных по штатным твердым грузам";
        private double _t6 => IsT6 ? 0 : _t1 * _k6 * K_нов_6.Coef / K1.Coef;
        private const double _k6 = 1.0;
        [Reactive] public Correction K_нов_6 { get; set; }
        [Reactive] public bool IsT6 { get; set; } = true;
        #endregion

        #region t7
        public static string T7 = "Ввод данных по возимым грузам";
        private double _t7 => IsT7 ? 0 : _t1 * K7.Coef * K_нов_7.Coef / K1.Coef;
        [Reactive] public Correction K7 { get; set; }
        public static List<Correction> s_Corrections3_4_4 = new List<Correction>()
        {
            new Correction("Не предусмотрены", 0),
            new Correction("Контейнеры", 1.0),
            new Correction("Жидкие грузы", 1.1),
            new Correction("Десант", 1.3)
        }; // k_7 Вид, номенклатура, расположение массы возимых грузов
        [Reactive] public Correction K_нов_7 { get; set; }
        [Reactive] public bool IsT7 { get; set; } = true;
        #endregion

        // t.3-3
        #region t8
        public static string T8 = "Ввод геометрии водонепроницаемых отсеков ";
        private double _t8 => IsT8 ? 0 : _q_ВО * N_ВО * K8.Coef * K_нов_8.Coef;
        private const double _q_ВО = 10;
        [Reactive] public Correction K8 { get; set; }
        public static List<Correction> s_Corrections3_4_5 = new List<Correction>()
        {
            new Correction("Традиционная архитектура", 1),
            new Correction("Наличие второго борта и др. особенности", 1.2)
        }; // k_8 Cложность геометрии ВО
        [Reactive] public Correction K_нов_8 { get; set; }
        [Reactive] public bool IsT8 { get; set; } = true;
        #endregion

        #region t9
        public static string T9 = "Ввод постоянных данных водонепроницаемых отсеков";
        private double _t9 => IsT9 ? 0 : _t8 * _k9 * K_нов_9.Coef;
        private const double _k9 = 2.7;
        [Reactive] public Correction K_нов_9 { get; set; }
        [Reactive] public bool IsT9 { get; set; } = true;
        #endregion

        #region t10
        public static string T10 = "Ввод данных по датчикам затопления отсеков (заполнения цистерн)";
        private double _t10 => IsT10 ? 0 : _t8 * K10.Coef * K_нов_10.Coef;
        [Reactive] public Correction K10 { get; set; }
        public static List<Correction> s_Corrections3_4_6 = new List<Correction>()
        {
            new Correction("Датчики отсутствуют", 0),
            new Correction("Необходим ввод датчиков", 0.1)
        }; // k_10 Наличие / отсутствие датчиков
        [Reactive] public Correction K_нов_10 { get; set; }
        [Reactive] public bool IsT10 { get; set; } = true;
        #endregion

        #endregion

        #endregion


        #region ПОЖАРЫ И ВОДА _T_БЖ

        private double _T_БЖ => _t11 + _t12 + _t13 + _t14 + _t15 + _t16 + _t17 + _t18 +
                                _t19 + _t20 + _t21 + _t22 + _t23 + _t24 + _t25; // трудоёмкость заполнения (корректировки) ИМ задач непотопляемости в части данных по кораблю в целом


        private bool _isT_БЖ = true;
        public bool IsT_БЖ // Reactive
        {
            get => _isT_БЖ;
            set
            {
                IsT11 = IsT12 = IsT13 = IsT14 = IsT15 = IsT16 = IsT17 = IsT18
                    = IsT19 = IsT20 = IsT21 = IsT22 = IsT23 = IsT24 = IsT25 = value;
                this.RaiseAndSetIfChanged(ref _isT_БЖ, value);
            }
        }


        #region _ti

        // t.3-5
        #region t11
        public static string T11 = "Ввод геометрии корабельных (судовых) помещений";
        private double _t11 => IsT1 ? 0 : _q_пом * N_пом * _k11 * K_нов_11.Coef;
        private const double _q_пом = 10; // 
        private const double _k11 = 1.2;
        [Reactive] public Correction K_нов_11 { get; set; }
        [Reactive] public bool IsT11 { get; set; } = true;
        #endregion

        #region t12
        public static string T12 = "Ввод геометрии аварийных участков (АУ) на планах палуб, платформ, ярусов надстроек";
        private double _t12 => IsT12 ? 0 : _q_АУ * N_АУ * N_пал * _k12 * K_нов_12.Coef;
        private const double _q_АУ = 1.0;
        private const double _k12 = 0.8;
        [Reactive] public Correction K_нов_12 { get; set; }
        [Reactive] public bool IsT12 { get; set; } = true;
        #endregion

        #region t13
        public static string T13 = "Ввод в корабельных помещениях расположения и типа дверей, люков, иллюминаторов, трапов и т.п.";
        private double _t13 => IsT13 ? 0 : _t11 * _k13 * K_нов_13.Coef / _k11;
        private const double _k13 = 2.5;
        [Reactive] public Correction K_нов_13 { get; set; }
        [Reactive] public bool IsT13 { get; set; } = true;
        #endregion

        #region t14
        public static string T14 = "Ввод расположения в корабельных помещениях и на открытых палубах средств управления стационарными средствами пожаротушения, удаления воды и вентиляции";
        private double _t14 => IsT14 ? 0 : _t11 * _k14 * K_нов_14.Coef / _k11;
        private const double _k14 = 2.2;
        [Reactive] public Correction K_нов_14 { get; set; }
        [Reactive] public bool IsT14 { get; set; } = true;
        #endregion

        #region t15
        public static string T15 = "Ввод расположения в корабельных помещениях АСИ, СИЗ и средств связи";
        private double _t15 => IsT15 ? 0 : _t11 * _k15 * K_нов_15.Coef / _k11;
        private const double _k15 = 3.5;
        [Reactive] public Correction K_нов_15 { get; set; }
        [Reactive] public bool IsT15 { get; set; } = true;
        #endregion

        #region t16
        public static string T16 = "Ввод данных по особенностям корабельных помещений с точки зрения опасности возникновения пожара, возможности затопления и др.";
        private double _t16 => IsT16 ? 0 : _t11 * _k16 * K_нов_16.Coef / _k11;
        private const double _k16 = 2.0;
        [Reactive] public Correction K_нов_16 { get; set; }
        [Reactive] public bool IsT16 { get; set; } = true;
        #endregion

        #region t17
        public static string T17 = "Ввод данных по особенностям АУ";
        private double _t17 => IsT17 ? 0 : _t12 * _k17 * K_нов_17.Coef / _k12;
        private const double _k17 = 5.0;
        [Reactive] public Correction K_нов_17 { get; set; }
        [Reactive] public bool IsT17 { get; set; } = true;
        #endregion

        #region t18
        public static string T18 = "Ввод расположения в корабельных помещениях устройств обесточивания электрооборудования";
        private double _t18 => IsT18 ? 0 : _t11 * _k18 * K_нов_18.Coef / _k11;
        private const double _k18 = 3.2;
        [Reactive] public Correction K_нов_18 { get; set; }
        [Reactive] public bool IsT18 { get; set; } = true;
        #endregion

        #region t19
        public static string T19 = "Ввод схем трассировки трубопроводов ОКС в привязке к корабельным помещениям";
        private double _t19 => IsT19 ? 0 : _q_ОКС * N_ОКС * _k19 * K_нов_19.Coef;
        private const double _q_ОКС = 4.5;
        private const double _k19 = 1.3;
        [Reactive] public Correction K_нов_19 { get; set; }
        [Reactive] public bool IsT19 { get; set; } = true;
        #endregion

        #region t20
        public static string T20 = "Ввод расположения в корабельных помещениях органов управления ОКС";
        private double _t20 => IsT20 ? 0 : _t19 * _k20 * K_нов_20.Coef / _k19;
        private const double _k20 = 3.0;
        [Reactive] public Correction K_нов_20 { get; set; }
        [Reactive] public bool IsT20 { get; set; } = true;
        #endregion

        #region t21
        public static string T21 = "Ввод данных по наличию датчиков пожарной сигнализации в корабельных помещениях";
        private double _t21 => IsT21 ? 0 : _t11 * _k21 * K_нов_21.Coef / _k11;
        private const double _k21 = 0.7;
        [Reactive] public Correction K_нов_21 { get; set; }
        [Reactive] public bool IsT21 { get; set; } = true;
        #endregion

        #region t22
        public static string T22 = "Ввод данных по наличию датчиков закрытия дверей и люков";
        private double _t22 => IsT22 ? 0 : _t11 * _k22 * K_нов_22.Coef / _k19;
        private const double _k22 = 0.8;
        [Reactive] public Correction K_нов_22 { get; set; }
        [Reactive] public bool IsT22 { get; set; } = true;
        #endregion

        #region t23
        public static string T23 = "Ввод данных по характеристикам технических средств ОКС";
        private double _t23 => IsT23 ? 0 : _t19 * _k23 * K_нов_23.Coef / _k19;
        private const double _k23 = 0.8;
        [Reactive] public Correction K_нов_23 { get; set; }
        [Reactive] public bool IsT23 { get; set; } = true;
        #endregion

        #region t24
        public static string T24 = "Ввод данных по границам рубежей обороны";
        private double _t24 => IsT24 ? 0 : _t12 * _k24 * K_нов_24.Coef / _k12;
        private const double _k24 = 1.2;
        [Reactive] public Correction K_нов_24 { get; set; }
        [Reactive] public bool IsT24 { get; set; } = true;
        #endregion

        #region t25
        public static string T25 = "Ввод данных по особенностям АК";
        private double _t25 => IsT25 ? 0 : _q_АК * N_АК * _k25 * K_нов_25.Coef;
        private const double _q_АК = 0.3;
        private const double _k25 = 0.9;
        [Reactive] public Correction K_нов_25 { get; set; }
        [Reactive] public bool IsT25 { get; set; } = true;
        #endregion

        #endregion

        #endregion


        public static List<Correction> s_Corrections3_6 = new List<Correction>()
        {
            new Correction("Полная разработка", 1),
            new Correction("Очень высокая", 0.85),
            new Correction("Высокая", 0.70),
            new Correction("Средняя", 0.5),
            new Correction("Низкая", 0.3),
            new Correction("Очень низкая", 0.15),
            new Correction("Не требуется", 0)
        }; // k_нов Коэффициент новизны разработки


        #region 3.6. ПРОТОКОЛ СОПРЯЖЕНИЯ С ВНЕШНИМИ СИСТЕМАМИ
        [Reactive] public bool IsT_прот { get; set; } = true;
        [Reactive] public int N_прот { get; set; }
        private double _T_прот => N_прот * 56; // 56 нормо-часов на один протокол
        #endregion


        #region 3.7. КРЕНОВАНИЕ И ТАРИРОРВКА _T_кк
        [Reactive] public bool IsT_кк { get; set; } = true;
        private double _T_кк => _t5 + _t9 + _t10; // (9) корректировка ИМ СПО по результатам кренования корабля и тарировки цистерн
        #endregion


        #region 3.8. СРАВНИТЕЛЬНЫЕ РАСЧЁТЫ ПОСАДКИ И ОСТОЙЧИВОСТИ _T_ср
        [Reactive] public bool IsT_ср { get; set; } = true;
        private double _T_ср => N_ср * _q_ср;// (10) сравнительные расчёты посадки и остойчивости
        private double _q_ср = 0.5;
        [Reactive] public int N_ср { get; set; } // количество производимых расчётов
        #endregion


        #region 3.9. ОТЛАДКА ИНФ-ТЕХ СОПРЯЖЕНИЯ _T_ос
        [Reactive] public bool IsT_ос { get; set; } = true;
        [Reactive] public ObservableCollection<Отладка> Отладки { get; set; } = new ObservableCollection<Отладка>();
        private double _T_ос => Отладки.Sum(o => o._T_ос); // (11) отладка инф-тех сопряж. СПО с внешними ист. инф-ии

        public struct Отладка
        {
            public string Name;
            public int K;    // количество сотрудников, принимающих участие в отладке сопряжения
            public double T; // длительность отладки

            public double _T_ос => K * T;

            public Отладка(string name, int k, double t)
            {
                Name = name;
                K = k;
                T = t;
            }

            public override string ToString()
            {
                return $"Отладка: {Name}. T_ос:{_T_ос} = k:{K} * t:{T}";
            }
        }

        #endregion

        #endregion
    }
}
