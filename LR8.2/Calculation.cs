using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8._2
{
    public class Calculation
    {
        public List<double>? root {  get; set; }
        public List<double>x { get; set; }
        public List<double>y { get; set; }
        public List<List<List<double>>> listSqurel;

        public Calculation(List<double> x, List<double> y) 
        {
            this.x = x;
            this.y = y;
        }
        public void Calc()
        {
            GaussianMethod gaussianMethod = new GaussianMethod();
            listSqurel = new List<List<List<double>>>();
            root = new List<double>();
            root = null;
            List<Model> models = new List<Model>
            {
                new Liner(),
                new InverselyProportional(),
                new UnKnownModel1(),
                new Parabol(),
                new UnknownModel2(),
            };

            foreach (var model in models)
            {
                listSqurel.Add(model.Suma(x, y));
            }
            root=gaussianMethod.Solve(listSqurel);
        }
       


    }
}
