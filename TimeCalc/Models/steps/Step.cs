using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TimeCalc
{
    public abstract class Step : ReactiveObject, IEntity
    {
        public int Id => GetHashCode();
        public abstract double MethodicId { get; }
        public abstract string MethodicName { get; }

        [Reactive] public string Name { get; set; }

        public abstract double CalcLabor();
        public double Labor => CalcLabor();

        public abstract Report CreateReport();

        protected Step()
        {
            Name = MethodicName;
            //       this.WhenAnyValue(step => step.Labor).Subscribe(step => Debug.WriteLine(Labor));
        }

        public static Step Create(int id, string name)
        {
            return id switch
            {
                1  => new Step01() { Name = name },
                2  => new Step02() { Name = name },
                3  => new Step03() { Name = name },
                4  => new Step04() { Name = name },
                5  => new Step05() { Name = name },
                6  => new Step06() { Name = name },
                7  => new Step07() { Name = name },
                8  => new Step08() { Name = name },
                9  => new Step09() { Name = name },
                10 => new Step10() { Name = name },
                11 => new Step11() { Name = name },
                12 => new Step12() { Name = name },
                13 => new Step13() { Name = name },
                14 => new Step14() { Name = name },
                15 => new Step15() { Name = name },
                16 => new Step10() { Name = name },
                17 => new Step17() { Name = name },
                18 => new Step18() { Name = name },
                19 => new Step19() { Name = name },
                _ => throw new Exception("No such ID"),
            };
        }
    }
}
