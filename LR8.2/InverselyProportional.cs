﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8._2
{
    public class InverselyProportional : IModel
    {
        public double Function(double a0, double a1, double x)
        {
            return a0+a1/x;
        }

        public string StringFunction(double a0, double a1)
        {
            return @$"y={a0}+{a1}/x";
        }

        public double[][] Suma(List<double> x, List<double> y)
        {
            double sumx = 0, sumy = 0;
            double sumx2 = 0, sumxy = 0;

            for (int i = 0; i < x.Count; i++)
            {
                sumx += 1.0 / x[i];
                sumy += y[i];
                sumx2 += 1.0 / (x[i] * x[i]);
                sumxy += y[i] / x[i];
            }

            return new double[][]
            {
        new double[] { x.Count, sumx, sumy },
        new double[] { sumx, sumx2, sumxy }
            };
        }

    }
}
