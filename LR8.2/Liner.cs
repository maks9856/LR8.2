using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8._2
{
    public class Liner:Model
    {
        public Liner() { }

        public double Function(double a0, double a1, double x)
        {
           return a0+a1*x;
        }

        public string StringFunction(double a0, double a1, double x)
        {
            return @$"y={a0.ToString("0.00")}+{a1.ToString("0.00")}*x";
        }

        public List<List<double>> Suma(List<double> x, List<double> y)
        {
            double xsum = 0;
            double ysum = 0;
            double xsum2 = 0;
            double sumxy = 0;
            for (int i = 0; i < x.Count; i++)
            {
                xsum += x[i];
                ysum += y[i];
                xsum2 += x[i] * x[i];
                sumxy += y[i] * x[i];
            }
            return new List<List<double>>
            {
                new List<double> { x.Count, xsum, ysum },
                new List<double> { xsum, xsum2, sumxy }
            };
        }
    }
}
