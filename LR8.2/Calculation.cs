using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LR8._2
{
    public class Calculation
    {
        public List<double> root { get; set; }
        public List<double> x { get; set; }
        public List<double> y { get; set; }
        public string function { get; set; }
        public List<double> calculatedy { get; set; }

        public double[][] listSqurel;

        public double sticky = 0;
        public Calculation(List<double> x, List<double> y)
        {
            this.x = x;
            this.y = y;
        }

        public void Calc(DataGrid dataGrid)
        {
            GaussianMethod gaussianMethod = new GaussianMethod();
            calculatedy = new List<double>();
            root = new List<double>();

            List<IModel> models = new List<IModel>
            {
                new Liner(),
                new InverselyProportional(),
                new UnKnownModel1(),
                new Parabol(),
                new UnknownModel2(),
            };

            double minSticky = double.MaxValue;
            IModel bestModel = null;

            foreach (var model in models)
            {
                calculatedy.Clear();
                listSqurel = model.Suma(x, y);
                root = gaussianMethod.Gauss(listSqurel);
                function = model.StringFunction(root[0], root[1]);
                for (int i = 0; i < x.Count; i++)
                {
                    calculatedy.Add(model.Function(root[0], root[1], x[i]));
                }

                double currentSticky = calculationSticky();

                if (currentSticky < minSticky)
                {
                    minSticky = currentSticky;
                    bestModel = model;
                }
            }

            if (bestModel != null)
            {
                root = gaussianMethod.Gauss(bestModel.Suma(x, y));
                function = bestModel.StringFunction(root[0], root[1]);
                calculatedy.Clear();
                for (int i = 0; i < x.Count; i++)
                {
                    calculatedy.Add(bestModel.Function(root[0], root[1], x[i]));
                }   
            }
        }

        public double calculationSticky()
        {
            sticky = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sticky += Math.Pow(y[i] - calculatedy[i], 2);
            }
            return sticky;
        }
    }
}
