﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8._2
{
    public class UnknownModel2 : IModel
    {
        public double Function(double a0, double a1, double x)
        {
            return x / (a0+a1*x);
        }

        public string StringFunction(double a0, double a1)
        {
            return @$"y=x/({a0}+{a1}*x)";
        }

        public double[][] Suma(List<double> x, List<double> y)
        {
            double sumx = 0, sumxy = 0, sumx2 = 0, sumx2y = 0;

            for (int i = 0; i < x.Count; i++)
            {
                sumx += x[i];
                sumxy += x[i] / y[i];
                sumx2 += x[i] * x[i];
                sumx2y += (x[i] * x[i]) / y[i];
            }

            return new double[][]
            {
             new double[] { x.Count, sumx, sumxy },
             new double[] { sumx, sumx2, sumx2y }
            };
        }

    }
}
