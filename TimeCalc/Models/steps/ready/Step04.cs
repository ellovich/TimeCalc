using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class Step04 : Step
    {
        public override double MethodicId => 4;
        public override string MethodicName => "3D моделирование";

        public override double CalcLabor()
        {
            return _T_ВВ + _T_ВР + _T_пом; // (ф.13, п.4.6, с.44) // трудоёмкость создания (доработки) интерактивных 3D-моделей корабля/судна
        }

        public override Report CreateReport()
        {
            return new Report(0, "");
        }


        #region DATA

        [Reactive] public int N_пал { get; set; }            // количество палуб
        [Reactive] public int N_пом { get; set; }            // количество помещений

        [Reactive] public Надстройки Надстр { get; set; }

        [Reactive] public Correction K_3D_нов { get; set; }  // коэффициент корректировки зависящий от новизны
        [Reactive] public Correction K_L { get; set; }       // сложность разработки в зависимости от наиб. длины корпуса
        [Reactive] public Correction K_1 { get; set; }       // сложность разработки в зависимости сложности геометрии обводов корпуса
        [Reactive] public Correction K_K { get; set; }       // качество конечной модели, опред. низко- или высокополигональным моделированием

        #region _T_ВВ  (ф.14)
        private double _T_ВВ => _T_корп + _T_надстр + _T_эл; // (ф.14, п.4.6.1, с.45) // внешний вид

        #region _T_корп   (ф.15)
        private double _T_корп => _T_O + _T_ВЧ;              // (ф.15, п.4.6.2, с.45) // корпус

        #region _T_O
        private double _T_O => _q_O * K_L.Coef * K_1.Coef * K_K.Coef * K_3D_нов.Coef;           // (ф.16, п.4.6.2, с.46) // обводы

        private const double _q_O = 20;                                                         // усред. норма времени на создание 3D-модели обводов корпуса
        public static readonly List<Correction> s_Corrections4_7_1 = new List<Correction>()
        {
            new Correction("< 60м", 1),
            new Correction("от 60 до 79м", 1.2),
            new Correction("от 80 до 99м", 1.6),
            new Correction("> 100м", 2.0),
        }; // значения для K_L
        public static readonly List<Correction> s_Corrections3_4_1 = new List<Correction>()
        {
            new Correction("Традиционные обводы корпуса", 1),
            new Correction("Сложные обводы носовой и кормовой оконечности", 1.2),
        }; // значения для K_1
        public static readonly List<Correction> s_Corrections4_7_2 = new List<Correction>()
        {
            new Correction("Низкополигональное", 1), 
            new Correction("Восокополигональное", 1.5),
        }; // значения для K_K
        #endregion

        #region _T_ВЧ
        private double _T_ВЧ => 0;                           // TODO конструктивные элементы подводной части корпуса 
        #endregion

        #endregion

        #region _T_надстр (ф.17)
        private double _T_надстр => Надстр.FullLabor();

        public class Надстройки
        {
            private List<Item> Items = new List<Item>();

            public double FullLabor()
            {
                return Items.Sum(x => x.Labor);
            }
        }
        public struct Надстройка
        {
            public static double s_maxL = 0; // длина наибольшей надстройки

            public double _l;                // длина надстройки
            public Correction _K_нов_3D;

            public Надстройка(double l, Correction K_нов_3D)
            {
                _l = l;
                _K_нов_3D = K_нов_3D;

                s_maxL = _l > s_maxL ? _l : s_maxL;
            }

            public double Labor()
            {
                double _T_O = 0; // TODO откуда брать?
                double k_надстр = _l / s_maxL;

                return _T_O * k_надстр * _K_нов_3D.Coef; // (ф.18, п.4.6.2.1, с.47)
            }
        }

        #endregion

        #region _T_эл     (ф.19)
        private double _T_эл => (_q_эл_В1 * _n_эл_В2) + (_q_эл_В2 * _n_эл_В2) + (_q_эл_Н1 * _n_эл_Н1 * K_3D_нов.Coef);

        private const double _q_эл_В1 = 40; // усред. норма для оборудования очень большого размера с высокой ст. деталировки
        private const double _q_эл_В2 = 16; // усред. норма для оборудования очень большого размера с низкой  ст. деталировки
        private const double _q_эл_Н1 = 16; // усред. норма для оборудования       большого размера с высокой ст. деталировки

        private const double _n_эл_В1 = 0;  // кол-во эл-ов оборуд. очень большого размера с высокой ст. деталировки
        private const double _n_эл_В2 = 0;  // кол-во эл-ов оборуд. очень большого размера с низкой  ст. деталировки
        private const double _n_эл_Н1 = 0;  // кол-во эл-ов оборуд.       большого размера с высокой ст. деталировки
        #endregion

        #endregion

        #region _T_ВР  (ф.20)

        private double _T_ВР => _T_ВВ * _k_ВР + K_3D_нов.Coef; // (ф.20, п.4.6.3, с.48) // внутренне расположение

        private double _k_ВР => 0.2 * N_пал + 0.01 * N_пом;    // коэффициент, учитывающих количество палуб и количество помещений
        public static readonly List<Correction> s_Corrections4_8 = new List<Correction>()
        {
            new Correction("Полная разработка", 1),
            new Correction("Очень высокая", 0.85),
            new Correction("Высокая", 0.7),
            new Correction("Средняя", 0.5),
            new Correction("Низкая", 0.3),
            new Correction("Очень низкая", 0.15),
        }; // K_3D_нов

        #endregion

        #region _T_пом (ф.??)
        private double _T_пом => 0; // TODO (ф., п.4.6., с.) // помещения
        #endregion

        #endregion
    }
}
