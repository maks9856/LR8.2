using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8._2
{
    public interface Model
    {
        List<List<double>> Suma(List<double> x, List<double> y);
        public double Function(double a0,double a1,double x);
        public string StringFunction(double a0, double a1, double x);
    }
}
