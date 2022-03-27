using System;

namespace TimeCalc
{
    public class Step16 : Step
    {
        public override double MethodicId => 19;
        public override string MethodicName => "Работа с гос. тайной";

        public override double CalcLabor()
        {
            //if (1 > 2)
            //    return StepsManager.Instance.FullLabor * 1.05;
            //else
            //    return StepsManager.Instance.FullLabor * 1.1;

            throw new NotImplementedException();
        }

        public override Report CreateReport()
        {
            string algo = "\n";
            return new Report(81, algo);
        }
    }
}
