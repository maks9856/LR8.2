using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8._2
{
    public class UnKnownModel1 : Model
    {
        public double Function(double a0, double a1, double x)
        {
            return 1 / (a0 + (a1 / x));
        }

        public string StringFunction(double a0, double a1, double x)
        {
            return @$"y=1/({a0}+({a1}/{x}))";
        }

        public List<List<double>> Suma(List<double> x, List<double> y)
        {
            double sumx = 0;
            double sumy = 0;
            double sumx2 = 0;
            double sumxy = 0;
            for(int i = 0; i < x.Count; i++)
            {
                sumx += x[i];
                sumy += 1/y[i];
                sumx2 += x[i]*x[i];
                sumxy += x[i] * y[i];
            }
            return new List<List<double>>
            {
              new List<double> { x.Count, sumx, sumy },
              new List<double> { sumx, sumx2, sumxy }
            };
        }
    }
}
