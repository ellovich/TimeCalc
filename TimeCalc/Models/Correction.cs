using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeCalc
{
    public readonly struct Correction
    {
        public string Name { get; }
        public double Coef { get; }

        public Correction(string name, double coef)
        {
            Name = name;
            Coef = coef;
        }

        public override string ToString()
        {
            return $"{Name} (коэф. = {Coef.Out()})";
        }
    }

    public struct Coefs
    {
        public string Name { get; set; }
        public List<Correction> Corrections { get; set; }

        public Coefs(string name, params Correction[] corrections)
        {
            Name = name;
            Corrections = corrections.ToList();
        }

        public override string ToString()
        {
            string str = $"{Name}:\n";
            foreach (var c in Corrections)
                str += c + "\n";

            return str;
        }
    } 
}
