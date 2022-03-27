using System;
using System.Collections.Generic;
using System.Text;

namespace TimeCalc
{
    public static class Extensions
    {
        public static string Out(this double x)
        {
            return x.ToString("0.###");
        }
    }
}
