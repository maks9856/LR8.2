using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8._2
{
    internal class Parabol : IModel
    {
        public double Function(double a0, double a1, double x)
        {
            return a0 + a1*x*x;
        }

        public string StringFunction(double a0, double a1)
        {
            return $"y={a0}+{a1}*x^2";
        }

        public double[][] Suma(List<double> x, List<double> y)
        {
            double sumx2 = 0;
            double sumy = 0;
            double sumx4 = 0;
            double sumyx2 = 0;

            for (int i = 0; i < x.Count; i++)
            {
                sumy += y[i];
                sumx2 += x[i] * x[i];
                sumx4 += x[i] * x[i] * x[i] * x[i];
                sumyx2 += y[i] * x[i] * x[i];
            }

            return new double[][]
            {
             new double[] { x.Count, sumx2, sumy },
             new double[] { sumx2, sumx4, sumyx2 }
            };
        }

    }
}
