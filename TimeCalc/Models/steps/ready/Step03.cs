using System;
using System.Collections.Generic;
using System.Diagnostics;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step03 : Step
    {
        public override double MethodicId => 3;
        public override string MethodicName => "Формирование ИМ СПО СИП БЖ";

        public override double CalcLabor()
        {
            return _T_ИМ;
        }

        public override Report CreateReport()
        {
            string rowT1 = $@"
<tr>
    <td>
        t<sub>1</sub>
    </td>
    <td>
        {T1}
    </td>
    <td>
        <tt>
        t<sub>1</sub> = q<sub>пш</sub> ⋅ n<sub>пш</sub> ⋅ k<sub>1</sub> * k<sub>нов</sub>
        </tt>
    </td>
    <td>
        <tt>
        q<sub>пш</sub> = {_q_пш.Out()} <br>
        n<sub>пш</sub> = {N_пш} <br>
        k<sub>1</sub> = {K1.Coef.Out()} <br>
        k<sub>нов</sub> = {K_нов_1.Coef.Out()} <br>
        </tt>
    </td>
    <td>
        {_t1.Out()}
    </td>
</tr>
";
            string rowT2 = $@"
<tr>
    <td>
        t<sub>2</sub>
    </td>
    <td>
        {T2}
    </td>
    <td>
        <tt>
        t<sub>2</sub>  = (t<sub>1</sub> ⋅ k<sub>2</sub>  ⋅ k<sub>нов</sub>) / k<sub>1</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>1</sub> = {_t1.Out()} <br>
        k<sub>2</sub> = {_k2.Out()} <br>
        k<sub>нов</sub> = {K_нов_2.Coef} <br>
        k<sub>1</sub> = {K1.Coef} <br>
        </tt>
    </td>
    <td>
        {_t2.Out()}
    </td>
</tr>
";
            string rowT3 = $@"
<tr>
    <td>
        t<sub>3</sub>
    </td>
    <td>
        {T3}
    </td>
    <td>
        <tt>
        t<sub>3</sub>  = (t<sub>1</sub> ⋅ k<sub>3</sub>  ⋅ k<sub>нов</sub>) / k<sub>1</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>1</sub> = {_t1.Out()} <br>
        k<sub>3</sub> = {K3.Coef} <br>
        k<sub>нов</sub> = {K_нов_3.Coef} <br>
        k<sub>1</sub> = {K1.Coef} <br>
        </tt>
    </td>
    <td>
        {_t3.Out()}
    </td>
</tr>
";
            string rowT4 = $@"
<tr>
    <td>
        t<sub>4</sub>
    </td>
    <td>
        {T4}
    </td>
    <td>
        <tt>
        t<sub>4</sub>  = (t<sub>1</sub> ⋅ k<sub>4</sub>  ⋅ k<sub>нов</sub>) / k<sub>1</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>1</sub> = {_t1.Out()} <br>
        k<sub>4</sub> = {_k4} <br>
        k<sub>нов</sub> = {K_нов_4.Coef} <br>
        k<sub>1</sub> = {K1.Coef} <br>
        </tt>
    </td>
    <td>
        {_t4.Out()}
    </td>
</tr>
";
            string rowT5 = $@"
<tr>
    <td>
        t<sub>5</sub>
    </td>
    <td>
        {T5}
    </td>
    <td>
        <tt>
        t<sub>5</sub>  = (t<sub>1</sub> ⋅ k<sub>5</sub>  ⋅ k<sub>нов</sub>) / k<sub>1</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>1</sub> = {_t1.Out()} <br>
        k<sub>5</sub> = {_k5} <br>
        k<sub>нов</sub> = {K_нов_5.Coef} <br>
        k<sub>1</sub> = {K1.Coef} <br>
        </tt>
    </td>
    <td>
        {_t5.Out()}
    </td>
</tr>
";
            string rowT6 = $@"
<tr>
    <td>
        t<sub>6</sub>
    </td>
    <td>
        {T6}
    </td>
    <td>
        <tt>
        t<sub>6</sub>  = (t<sub>1</sub> ⋅ k<sub>6</sub>  ⋅ k<sub>нов</sub>) / k<sub>1</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>1</sub> = {_t1.Out()} <br>
        k<sub>6</sub> = {_k6} <br>
        k<sub>нов</sub> = {K_нов_6.Coef} <br>
        k<sub>1</sub> = {K1.Coef} <br>
        </tt>
    </td>
    <td>
        {_t6.Out()}
    </td>
</tr>
";
            string rowT7 = $@"
<tr>
    <td>
        t<sub>7</sub>
    </td>
    <td>
        {T7}
    </td>
    <td>
        <tt>
        t<sub>7</sub>  = (t<sub>1</sub> ⋅ k<sub>7</sub>  ⋅ k<sub>нов</sub>) / k<sub>1</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>1</sub> = {_t1.Out()} <br>
        k<sub>2</sub> = {K7.Coef} <br>
        k<sub>нов</sub> = {K_нов_7.Coef} <br>
        k<sub>1</sub> = {K1.Coef} <br>
        </tt>
    </td>
    <td>
        {_t7.Out()}
    </td>
</tr>
";

            string rowT8 = $@"
<tr>
    <td>
        t<sub>8</sub>
    </td>
    <td>
        {T8}
    </td>
    <td>
        <tt>
        t<sub>8</sub>  = q<sub>ВО</sub> ⋅ n<sub>ВО</sub> ⋅ k<sub>8</sub> ⋅ k<sub>нов</sub>
        </tt>
    </td>
    <td>
        <tt>
        q<sub>ВО</sub> = {_q_ВО.Out()} <br>
        n<sub>ВО</sub> = {N_ВО} <br>
        k<sub>8</sub> = {K8.Coef.Out()} <br>
        k<sub>нов</sub> = {K_нов_8.Coef.Out()} <br>
        </tt>
    </td>
    <td>
        {_t8.Out()}
    </td>
</tr>
";
            string rowT9 = $@"
<tr>
    <td>
        t<sub>9</sub>
    </td>
    <td>
        {T9}
    </td>
    <td>
        <tt>
        t<sub>9</sub>  = t<sub>8</sub>  ⋅ k<sub>9</sub>  ⋅ k<sub>нов</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>8</sub> = {_t8.Out()} <br>
        k<sub>9</sub> = {_k9} <br>
        k<sub>нов</sub> = {K_нов_9.Coef.Out()} <br>
        </tt>
    </td>
    <td>
        {_t9.Out()}
    </td>
</tr>
";
            string rowT10 = $@"
<tr>
    <td>
        t<sub>10</sub>
    </td>
    <td>
        {T10}
    </td>
    <td>
        <tt>
        t<sub>10</sub> = t<sub>8</sub>  ⋅ k<sub>10</sub> ⋅ k<sub>нов</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>8</sub> = {_t8.Out()} <br>
        k<sub>10</sub> = {K10.Coef} <br>
        k<sub>нов</sub> = {K_нов_10.Coef.Out()} <br>
        </tt>
    </td>
    <td>
        {_t10.Out()}
    </td>
</tr>
";

            string rowT11 = $@"
<tr>
    <td>
        t<sub>11</sub>
    </td>
    <td>
        {T11}
    </td>
    <td>
        <tt>
        t<sub>11</sub> = q<sub>пом</sub> ⋅ n<sub>пом</sub> ⋅ k<sub>11</sub> * k<sub>нов</sub>
        </tt>
    </td>
    <td>
        <tt>
        q<sub>пом</sub> = {_q_пом.Out()} <br>
        n<sub>пом</sub> = {N_пом} <br>
        k<sub>11</sub> = {_k11.Out()} <br>
        k<sub>нов</sub> = {K_нов_11.Coef.Out()} <br>
        </tt>
    </td>
    <td>
        {_t11.Out()}
    </td>
</tr>
";
            string rowT12 = $@"
<tr>
    <td>
        t<sub>12</sub>
    </td>
    <td>
        {T12}
    </td>
    <td>
        <tt>
        t<sub>12</sub> = q<sub>АУ</sub> ⋅ n<sub>АУ</sub> ⋅ n<sub>пал</sub> ⋅ k<sub>12</sub> * k<sub>нов</sub>
        </tt>
    </td>
    <td>
        <tt>
        q<sub>АУ</sub> = {_q_АУ.Out()} <br>
        n<sub>АУ</sub> = {N_АУ} <br>
        n<sub>пал</sub> = {N_пал} <br>
        k<sub>12</sub> = {_k12.Out()} <br>
        k<sub>нов</sub> = {K_нов_12.Coef.Out()} <br>
        </tt>
    </td>
    <td>
        {_t12.Out()}
    </td>
</tr>
";
            string rowT13 = $@"
<tr>
    <td>
        t<sub>13</sub>
    </td>
    <td>
        {T13}
    </td>
    <td>
        <tt>
        t<sub>13</sub>  = (t<sub>11</sub> ⋅ k<sub>13</sub>  ⋅ k<sub>нов</sub>) / k<sub>11</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>11</sub> = {_t11.Out()} <br>
        k<sub>13</sub> = {_k13.Out()} <br>
        k<sub>нов</sub> = {K_нов_13.Coef.Out()} <br>
        k<sub>11</sub> = {_k11.Out()} <br>
        </tt>
    </td>
    <td>
        {_t13.Out()}
    </td>
</tr>
";
            string rowT14 = $@"
<tr>
    <td>
        t<sub>14</sub>
    </td>
    <td>
        {T14}
    </td>
    <td>
        <tt>
        t<sub>14</sub> = (t<sub>11</sub> ⋅ k<sub>14</sub>  ⋅ k<sub>нов</sub>) / k<sub>11</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>11</sub> = {_t11.Out()} <br>
        k<sub>14</sub> = {_k14.Out()} <br>
        k<sub>нов</sub> = {K_нов_14.Coef.Out()} <br>
        k<sub>11</sub> = {_k11.Out()} <br>
        </tt>
    </td>
    <td>
        {_t14.Out()}
    </td>
</tr>
";
            string rowT15 = $@"
<tr>
    <td>
        t<sub>15</sub>
    </td>
    <td>
        {T15}
    </td>
    <td>
        <tt>
        t<sub>15</sub> = (t<sub>11</sub> ⋅ k<sub>15</sub>  ⋅ k<sub>нов</sub>) / k<sub>11</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>11</sub> = {_t11.Out()} <br>
        k<sub>15</sub> = {_k15.Out()} <br>
        k<sub>нов</sub> = {K_нов_15.Coef.Out()} <br>
        k<sub>11</sub> = {_k11.Out()} <br>
        </tt>
    </td>
    <td>
        {_t15.Out()}
    </td>
</tr>
";
            string rowT16 = $@"
<tr>
    <td>
        t<sub>16</sub>
    </td>
    <td>
        {T16}
    </td>
    <td>
        <tt>
        t<sub>16</sub>  = (t<sub>11</sub> ⋅ k<sub>16</sub>  ⋅ k<sub>нов</sub>) / k<sub>11</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>11</sub> = {_t11.Out()} <br>
        k<sub>16</sub> = {_k16.Out()} <br>
        k<sub>нов</sub> = {K_нов_16.Coef.Out()} <br>
        k<sub>11</sub> = {_k11.Out()} <br>
        </tt>
    </td>
    <td>
        {_t16.Out()}
    </td>
</tr>
";
            string rowT17 = $@"
<tr>
    <td>
        t<sub>17</sub>
    </td>
    <td>
        {T17}
    </td>
    <td>
        <tt>
        t<sub>17</sub> = (t<sub>12</sub> ⋅ k<sub>17</sub>  ⋅ k<sub>нов</sub>) / k<sub>12</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>12</sub> = {_t12.Out()} <br>
        k<sub>17</sub> = {_k17.Out()} <br>
        k<sub>нов</sub> = {K_нов_17.Coef.Out()} <br>
        k<sub>12</sub> = {_k12.Out()} <br>
        </tt>
    </td>
    <td>
        {_t17.Out()}
    </td>
</tr>
";
            string rowT18 = $@"
<tr>
    <td>
        t<sub>18</sub>
    </td>
    <td>
        {T18}
    </td>
    <td>
        <tt>
        t<sub>18</sub> = (t<sub>11</sub> ⋅ k<sub>18</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>11</sub> = {_t11.Out()} <br>
        k<sub>18</sub> = {_k18.Out()} <br>
        k<sub>нов</sub> = {K_нов_18.Coef.Out()} <br>
        k<sub>11</sub> = {_k11.Out()} <br>
        </tt>
    </td>
    <td>
        {_t18.Out()}
    </td>
</tr>
";
            string rowT19 = $@"
<tr>
    <td>
        t<sub>19</sub>
    </td>
    <td>
        {T19}
    </td>
    <td>
        <tt>
        t<sub>19</sub> = q<sub>ОКС</sub> ⋅ n<sub>ОКС</sub> ⋅ k<sub>19</sub> ⋅ k<sub>нов</sub>
        </tt>
    </td>
    <td>
        <tt>
        q<sub>ОКС</sub> = {_q_ОКС.Out()} <br>
        n<sub>ОКС</sub> = {N_ОКС} <br>
        k<sub>19</sub> = {_k19.Out()} <br>
        k<sub>нов</sub> = {K_нов_19.Coef.Out()} <br>
        </tt>
    </td>
    <td>
        {_t19.Out()}
    </td>
</tr>
";
            string rowT20 = $@"
<tr>
    <td>
        t<sub>20</sub>
    </td>
    <td>
        {T20}
    </td>
    <td>
        <tt>
        t<sub>20</sub> = (t<sub>19</sub> ⋅ k<sub>20</sub> ⋅ k<sub>нов</sub>) / k<sub>19</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>19</sub> = {_t19.Out()} <br>
        k<sub>20</sub> = {_k20.Out()} <br>
        k<sub>нов</sub> = {K_нов_20.Coef.Out()} <br>
        k<sub>19</sub> = {_k19.Out()} <br>
        </tt>
    </td>
    <td>
        {_t20.Out()}
    </td>
</tr>
";
            string rowT21 = $@"
<tr>
    <td>
        t<sub>21</sub>
    </td>
    <td>
        {T21}
    </td>
    <td>
        <tt>
        t<sub>21</sub> = (t<sub>11</sub> ⋅ k<sub>21</sub>  ⋅ k<sub>нов</sub>) / k<sub>11</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>11</sub> = {_t11.Out()} <br>
        k<sub>21</sub> = {_k21.Out()} <br>
        k<sub>нов</sub> = {K_нов_21.Coef.Out()} <br>
        k<sub>11</sub> = {_k11.Out()} <br>
        </tt>
    </td>
    <td>
        {_t21.Out()}
    </td>
</tr>
";
            string rowT22 = $@"
<tr>
    <td>
        t<sub>22</sub>
    </td>
    <td>
        {T22}
    </td>
    <td>
        <tt>
        t<sub>22</sub> = (t<sub>11</sub> ⋅ k<sub>22</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>11</sub> = {_t11.Out()} <br>
        k<sub>22</sub> = {_k22.Out()} <br>
        k<sub>нов</sub> = {K_нов_22.Coef.Out()} <br>
        k<sub>11</sub> = {_k11.Out()} <br>
        </tt>
    </td>
    <td>
        {_t22.Out()}
    </td>
</tr>
";
            string rowT23 = $@"
<tr>
    <td>
        t<sub>23</sub>
    </td>
    <td>
        {T23}
    </td>
    <td>
        <tt>
        t<sub>23</sub> = (t<sub>19</sub> ⋅ k<sub>23</sub>  ⋅ k<sub>нов</sub>) / k<sub>19</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>19</sub> = {_t19.Out()} <br>
        k<sub>23</sub> = {_k23.Out()} <br>
        k<sub>нов</sub> = {K_нов_23.Coef.Out()} <br>
        k<sub>19</sub> = {_k19.Out()} <br>
        </tt>
    </td>
    <td>
        {_t23.Out()}
    </td>
</tr>
";
            string rowT24 = $@"
<tr>
    <td>
        t<sub>24</sub>
    </td>
    <td>
        {T24}
    </td>
    <td>
        <tt>
        t<sub>24</sub> = (t<sub>12</sub> ⋅ k<sub>24</sub>  ⋅ k<sub>нов</sub>) / k<sub>12</sub>
        </tt>
    </td>
    <td>
        <tt>
        t<sub>12</sub> = {_t12.Out()} <br>
        k<sub>24</sub> = {_k24.Out()} <br>
        k<sub>нов</sub> = {K_нов_24.Coef.Out()} <br>
        k<sub>12</sub> = {_k12.Out()} <br>
        </tt>
    </td>
    <td>
        {_t24.Out()}
    </td>
</tr>
";
            string rowT25 = $@"
<tr>
    <td>
        t<sub>25</sub>
    </td>
    <td>
        {T25}
    </td>
    <td>
        <tt>
        t<sub>25</sub> = q<sub>АК</sub> ⋅ n<sub>АК</sub> ⋅ k<sub>25</sub> * k<sub>нов</sub>
        </tt>
    </td>
    <td>
        <tt>
        q<sub>АК</sub> = {_q_АК.Out()} <br>
        n<sub>АК</sub> = {N_АК} <br>
        k<sub>25</sub> = {_k25.Out()} <br>
        k<sub>нов</sub> = {K_нов_25.Coef.Out()} <br>
        </tt>
    </td>
    <td>
        {_t15.Out()}
    </td>
</tr>
";

            string html = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом 3 - {MethodicName}.</p>

T<sub>ИМ</sub> = T<sub>Н</sub> + T<sub>БЖ</sub> = {_T_Н} + {_T_БЖ} = {_T_ИМ} <br>
T<sub>Н</sub> = T<sub>К</sub> + T<sub>ВО</sub> = {_T_K} + {_T_ВО} = {_T_Н} <br>


{(IsT_К ?
$@"
<table>
    <caption>т.3-2 Трудоёмкость работ по формированию (корректировке) ИМ в части данных по кораблю (судну) в целом</caption>
    <tr>
        <th style=""width:5%"">t<sub>i</sub></th>
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
    <caption>т.3-3 Трудоёмкость работ по заполнению (корректировке) ИМ в части данных по ВО корпуса</caption>
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


<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";

            return new Report(31, html);
        }

        public Step03()
        {
            this.WhenAnyValue(
                x => x.N_пш,
                x => x.N_ВО,
                x => x.K1,
                x => x.K_нов_1,
                //x => x.K2,
                x => x.K_нов_2).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K3,
                x => x.K_нов_3,
                x => x.K_нов_4,
                x => x.K_нов_5,
                x => x.K_нов_6,
                x => x.K_нов_7).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K8,
                x => x.K_нов_8,
                x => x.K_нов_9,
                x => x.K10,
                x => x.K_нов_10).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.N_пом,
                x => x.N_АУ,
                x => x.N_пал,
                x => x.N_ОКС,
                x => x.N_АК).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K_нов_11,
                x => x.K_нов_12,
                x => x.K_нов_13,
                x => x.K_нов_14,
                x => x.K_нов_15,
                x => x.K_нов_16,
                x => x.K_нов_17).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K_нов_18,
                x => x.K_нов_19,
                x => x.K_нов_20,
                x => x.K_нов_21,
                x => x.K_нов_22,
                x => x.K_нов_23,
                x => x.K_нов_24).Subscribe((_) => CalcLabor());

            this.WhenAnyValue(
                x => x.K_нов_15).Subscribe((_) => CalcLabor());               
        }


        #region DATA

        private double _T_ИМ => _T_Н + _T_БЖ; // общая трудоёмкость формирования ИМ СПО СИП

        #region НЕПОТОПЛЯЕМОСТЬ _T_Н

        [Reactive] public int N_пш { get; set; }  // количество практических шпангоутов
        [Reactive] public int N_ВО { get; set; }  // количество ВО судна, включая газоплотные отделения надстройки

        private double _T_Н => _T_K + _T_ВО; // трудоёмкость формирования ИМ задач непотопляемости
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
        private double _t1 => _q_пш * N_пш * K1.Coef * K_нов_1.Coef;
        private const double _q_пш = 1.6;
        [Reactive] public Correction K1 { get; set; }
        public static List<Correction> s_Corrections3_4_1 = new List<Correction>()
        {
            new Correction("Традиционные обводы корпуса", 1),
            new Correction("Сложные обводы носовой и кормовой оконечности", 1.2)
        }; // k_1 Cложность геометрии обводов корпуса
        [Reactive] public Correction K_нов_1 { get; set; }
        [Reactive] public bool IsT1 { get; set; } = true;

        //private bool _isT1 = true;
        //public bool IsT1 // Reactive
        //{
        //    get => _isT1;
        //    set
        //    {
        //        Set_T_К();
        //        this.RaiseAndSetIfChanged(ref _isT1, value);
        //    }
        //}
        #endregion

        #region t2
        public static string T2 = "Ввод геометрии палуб, платформ, ярусов надстроек и др.";
        private double _t2 => _t1 * _k2 * K_нов_2.Coef / K1.Coef;
        private double _k2 => N_пал < 6 ? 1.8 : 1.8 + 0.1 * (N_пал - 5); // выбор не нужен
        //private Correction _K2;
        //public Correction K2
        //{
        //    get => _K2;
        //    set
        //    {
        //        _K2 = N_пал < 6 ? s_Corrections3_4_2[0] : s_Corrections3_4_2[1];
        //        this.RaiseAndSetIfChanged(ref _K2, value);
        //    }
        //}
        //public static List<Correction> s_Corrections3_4_2 = new List<Correction>()
        //{
        //    new Correction("Менее 6", 1.8),
        //    new Correction("6 и более", 1.8 + 0.1 * (double.MaxValue - 5)), // TODO Неверная подсказка!
        //}; // k_2 Количество палуб и яросов надстройки (n_пал)
        [Reactive] public Correction K_нов_2 { get; set; }
        [Reactive] public bool IsT2 { get; set; } = true;
        #endregion

        #region t3
        public static string T3 = "Ввод геометрии выступающих частей";
        private double _t3 => _t1 * K3.Coef * K_нов_3.Coef / K1.Coef;
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
        private double _t4 => _t1 * _k4 * K_нов_4.Coef / K1.Coef;
        private const double _k4 = 3.0;
        [Reactive] public Correction K_нов_4 { get; set; }
        [Reactive] public bool IsT4 { get; set; } = true;
        #endregion

        #region t5
        public static string T5 = "Ввод постоянных данных по кораблю";
        private double _t5 => _t1 * _k5 * K_нов_5.Coef / K1.Coef;
        private const double _k5 = 2.2;
        [Reactive] public Correction K_нов_5 { get; set; }
        [Reactive] public bool IsT5 { get; set; } = true;
        #endregion

        #region t6
        public static string T6 = "Ввод данных по штатным твердым грузам";
        private double _t6 => _t1 * _k6 * K_нов_6.Coef / K1.Coef;
        private const double _k6 = 1.0;
        [Reactive] public Correction K_нов_6 { get; set; }
        [Reactive] public bool IsT6 { get; set; } = true;
        #endregion

        #region t7
        public static string T7 = "Ввод данных по возимым грузам";
        private double _t7 => _t1 * K7.Coef * K_нов_7.Coef / K1.Coef;
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
        private double _t8 => _q_ВО * N_ВО * K8.Coef * K_нов_8.Coef;
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
        private double _t9 => _t8 * _k9 * K_нов_9.Coef;
        private const double _k9 = 2.7;
        [Reactive] public Correction K_нов_9 { get; set; }
        [Reactive] public bool IsT9 { get; set; } = true;
        #endregion

        #region t10
        public static string T10 = "Ввод данных по датчикам затопления отсеков (заполнения цистерн)";
        private double _t10 => _t8 * K10.Coef * K_нов_10.Coef;
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

        [Reactive] public int N_пом { get; set; }  // количество практических шпангоутов
        [Reactive] public int N_АУ { get; set; }   // количество практических шпангоутов
        [Reactive] public int N_пал { get; set; }  // количество практических шпангоутов
        [Reactive] public int N_ОКС { get; set; }  // количество практических шпангоутов
        [Reactive] public int N_АК { get; set; }   // количество практических шпангоутов

        private double _T_БЖ => _t11 + _t12 + _t13 + _t14 + _t15 + _t16 + _t17 + _t18 +
                                _t19 + _t20 + _t21 + _t22 + _t23 + _t24 + _t25; // трудоёмкость заполнения (корректировки) ИМ задач непотопляемости в части данных по кораблю в целом

        private bool _isT_БЖ = true;
        public bool IsT_БЖ
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
        private double _t11 => _q_пом * N_пом * _k11 * K_нов_11.Coef;
        private const double _q_пом = 10; // 
        private const double _k11 = 1.2;
        [Reactive] public Correction K_нов_11 { get; set; }
        [Reactive] public bool IsT11 { get; set; } = true;
        #endregion

        #region t12
        public static string T12 = "Ввод геометрии аварийных участков (АУ) на планах палуб, платформ, ярусов надстроек";
        private double _t12 => _q_АУ * N_АУ * N_пал * _k12 * K_нов_12.Coef;
        private const double _q_АУ = 1.0;
        private const double _k12 = 0.8;
        [Reactive] public Correction K_нов_12 { get; set; }
        [Reactive] public bool IsT12 { get; set; } = true;
        #endregion

        #region t13
        public static string T13 = "Ввод в корабельных помещениях расположения и типа дверей, люков, иллюминаторов, трапов и т.п.";
        private double _t13 => _t11 * _k13 * K_нов_13.Coef / _k11;
        private const double _k13 = 2.5;
        [Reactive] public Correction K_нов_13 { get; set; }
        [Reactive] public bool IsT13 { get; set; } = true;
        #endregion

        #region t14
        public static string T14 = "Ввод расположения в корабельных помещениях и на открытых палубах средств управления стационарными средствами пожаротушения, удаления воды и вентиляции";
        private double _t14 => _t11 * _k14 * K_нов_14.Coef / _k11;
        private const double _k14 = 2.2;
        [Reactive] public Correction K_нов_14 { get; set; }
        [Reactive] public bool IsT14 { get; set; } = true;
        #endregion

        #region t15
        public static string T15 = "Ввод расположения в корабельных помещениях АСИ, СИЗ и средств связи";
        private double _t15 => _t11 * _k15 * K_нов_15.Coef / _k11;
        private const double _k15 = 3.5;
        [Reactive] public Correction K_нов_15 { get; set; }
        [Reactive] public bool IsT15 { get; set; } = true;
        #endregion

        #region t16
        public static string T16 = "Ввод данных по особенностям корабельных помещений с точки зрения опасности возникновения пожара, возможности затопления и др.";
        private double _t16 => _t11 * _k16 * K_нов_16.Coef / _k11;
        private const double _k16 = 2.0;
        [Reactive] public Correction K_нов_16 { get; set; }
        [Reactive] public bool IsT16 { get; set; } = true;
        #endregion

        #region t17
        public static string T17 = "Ввод данных по особенностям АУ";
        private double _t17 => _t12 * _k17 * K_нов_17.Coef / _k12;
        private const double _k17 = 5.0;
        [Reactive] public Correction K_нов_17 { get; set; }
        [Reactive] public bool IsT17 { get; set; } = true;
        #endregion

        #region t18
        public static string T18 = "Ввод расположения в корабельных помещениях устройств обесточивания электрооборудования";
        private double _t18 => _t11 * _k18 * K_нов_18.Coef / _k11;
        private const double _k18 = 3.2;
        [Reactive] public Correction K_нов_18 { get; set; }
        [Reactive] public bool IsT18 { get; set; } = true;
        #endregion

        #region t19
        public static string T19 = "Ввод схем трассировки трубопроводов ОКС в привязке к корабельным помещениям";
        private double _t19 => _q_ОКС * N_ОКС * _k19 * K_нов_19.Coef;
        private const double _q_ОКС = 4.5;
        private const double _k19 = 1.3;
        [Reactive] public Correction K_нов_19 { get; set; }
        [Reactive] public bool IsT19 { get; set; } = true;
        #endregion

        #region t20
        public static string T20 = "Ввод расположения в корабельных помещениях органов управления ОКС";
        private double _t20 => _t19 * _k20 * K_нов_20.Coef / _k19;
        private const double _k20 = 3.0;
        [Reactive] public Correction K_нов_20 { get; set; }
        [Reactive] public bool IsT20 { get; set; } = true;
        #endregion

        #region t21
        public static string T21 = "Ввод данных по наличию датчиков пожарной сигнализации в корабельных помещениях";
        private double _t21 => _t11 * _k21 * K_нов_21.Coef / _k11;
        private const double _k21 = 0.7;
        [Reactive] public Correction K_нов_21 { get; set; }
        [Reactive] public bool IsT21 { get; set; } = true;
        #endregion

        #region t22
        public static string T22 = "Ввод данных по наличию датчиков закрытия дверей и люков";
        private double _t22 => _t11 * _k22 * K_нов_22.Coef / _k19;
        private const double _k22 = 0.8;
        [Reactive] public Correction K_нов_22 { get; set; }
        [Reactive] public bool IsT22 { get; set; } = true;
        #endregion

        #region t23
        public static string T23 = "Ввод данных по характеристикам технических средств ОКС";
        private double _t23 => _t19 * _k23 * K_нов_23.Coef / _k19;
        private const double _k23 = 0.8;
        [Reactive] public Correction K_нов_23 { get; set; }
        [Reactive] public bool IsT23 { get; set; } = true;
        #endregion

        #region t24
        public static string T24 = "Ввод данных по границам рубежей обороны";
        private double _t24 => _t12 * _k24 * K_нов_24.Coef / _k12;
        private const double _k24 = 1.2;
        [Reactive] public Correction K_нов_24 { get; set; }
        [Reactive] public bool IsT24 { get; set; } = true;
        #endregion

        #region t25
        public static string T25 = "Ввод данных по особенностям АК";
        private double _t25 => _q_АК * N_АК * _k25 * K_нов_25.Coef;
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
        };   //  k_нов Коэффициент новизны разработки

        //private void Set_T_К()
        //{
        //    _isT_К = IsT1 || IsT2 || IsT3 || IsT4 || IsT5 || IsT6 || IsT7;
        //}

        //private void Set_T_ВО()
        //{
        //    _isT_ВО = IsT8 || IsT9 || IsT10;
        //}

        //private void Set_T_БЖ()
        //{
        //    _isT_БЖ = IsT11 || IsT12 || IsT13 || IsT14 || IsT15 || IsT16 || IsT17 || 
        //        IsT18 || IsT19 || IsT20 || IsT21 || IsT22 || IsT23 || IsT24 || IsT25;
        //}

        #endregion
    }
}
