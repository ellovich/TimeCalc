using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public class StepsManager : ReactiveObject
    {
        public static StepsManager Instance { get; } = new StepsManager();

        public string ProjName { get; set; } = "22011";

        [Reactive] public ObservableCollection<Step> DoneSteps { get; set; } = new ObservableCollection<Step>()
        {
            new Step03() {Name = "Формирование ИМ СПО СИП БЖ"},
            // new Step01(),
            // new Step04(),
            new Step06() {Name = "Формирование электронной тех. библиотеки интерактивных документов"},
            //new Step036(),
            new Step02(),
            new Step14(),
            //new Step037(),
            new Step11(),
            new Step07(), 
            // new Step13(),
            //new Step038(),
            //new Step039(),

            new Step09(),
            new Step12(),
            new Step16(),
            new Step17(),
            new Step18(),
        };

        public double FullLabor => DoneSteps.Sum(st => st.Labor);

        public StepsManager()
        {
   //         this.WhenAnyObservable( x => DoneSteps.ToObservableChangeSet(x=>x)).Subscribe(x => Debug.WriteLine($"{x} CHANGED!"));
        }

        public Step CreateStep(int id, string name)
        {
            var step = Step.Create(id, name);
            Instance.DoneSteps.Add(step);

            return step;
        }

        public static List<(double, string)> s_StepsTemplates { get; } = new List<(double, string)>()
        {
            (3, "Формирование ИМ СПО СИП БЖ"),
            //(1, "Разработка (доработка) СПО СИП БЖ"),
            //(4, "Создание (доработка) 3D моделей корабля/судна"),
            (6, "Формирование электронной тех. библиотеки интерактивных документов"),
            //(3.6, "Разработка протокола сопряжения с внешними системами"),
            (2, "Разработка документации"),
            (14, "Закупка аппаратных и программных средств"),
            //(3.7, "Корректировки ИМ СПО по результатам кренования и тарирорки цистерн"),
            (11, "Обучение командного состава судна порядку исп. СПО"),
            (7, "Руководство проектом"),
            //(13, "Испытание и сдача СИП БЖ заказчику"),
            //(3.8, "Проведение сравнительных расчётов посадки и остойчивости"),
            //(3.9, "Отладка инф.-тех. сопряжения СПО с внешними источниками инф-ии"),

            (9, "Математическое моделирование"),
            (12, "Проведение испытаний"),
            (16, "Оформление отчётных материалов"),
            (17, "Каталогизация"),
            (18, "Изготовление оптических изделий"),
        };
    }
}

////(1, "Программирование задач, систем и комплексов"),
//(2, "Разработка документации"),
//(3, "Формирование ИМ СИП БЖ"),
////(4, "3D моделирование"),
////(5, "Создание баз данных"),
//(6, "Формирование электронной тех. библиотеки интерактивных документов"),
//(7, "Руководство проектом"),
////(8, "Разработка компьютерных обучающих и тренажных программ"),
////(9, "Математическое моделирование"),
////(10, "Разработка моделей по обеспечению экологической безопасности"),
//(11, "Обучение специалистов (пользователей) порядку использования СПО"),
//(12, "Проведение испытаний"),
////(13, "Проведение пуско-наладочных работ"),
//(14, "Закупка аппаратных и программных средств"),
////(15, "Сертификация программного обеспечения"),
////(16, "Оформление отчетных материалов"),
////(17, "Проведение работ по каталогизации"),
////(18, "Изготовление оптических изделий")
