using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8._2
{
    public class Liner:IModel
    {
        public Liner() { }

        public double Function(double a0, double a1, double x)
        {
           return a0+a1*x;
        }

        public string StringFunction(double a0, double a1)
        {
            return @$"y={a0.ToString("0.00")}+{a1.ToString("0.00")}*x";
        }

        public double[][] Suma(List<double> x, List<double> y)
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

            double[][] result = new double[2][];

            result[0] = new double[3];
            result[1] = new double[3];

            result[0][0] = x.Count;
            result[0][1] = xsum;
            result[0][2] = ysum;

            result[1][0] = xsum;
            result[1][1] = xsum2;
            result[1][2] = sumxy;

            return result;
        }

    }
}
