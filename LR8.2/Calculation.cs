using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using OxyPlot.Wpf;

namespace LR8._2
{
    public class Calculation
    {
        public List<double> x { get; set; }
        public List<double> y { get; set; }
        public List<double> root { get; set; }
        public string function { get; set; }
        public double sticky { get; set; }
        public IModel bestModel { get; private set; }

        public Calculation(List<double> x, List<double> y)
        {
            this.x = x;
            this.y = y;
        }

        public List<Result> Calc()
        {
            List<Result> result = new List<Result>();
            GaussianMethod gaussianMethod = new GaussianMethod();
            List<IModel> models = new List<IModel>
            {
                new Liner(),
                new InverselyProportional(),
                new UnKnownModel1(),
                new Parabol(),
                new UnknownModel2(),
            };

            double minSticky = double.MaxValue;

            foreach (var model in models)
            {
                double[][] listSqurel = model.Suma(x, y);
                root = gaussianMethod.Gauss(listSqurel);
                function = model.StringFunction(root[0], root[1]);

                List<double> calculatedy = new List<double>();
                for (int i = 0; i < x.Count; i++)
                {
                    calculatedy.Add(model.Function(root[0], root[1], x[i]));
                }

                sticky = calculationSticky(y, calculatedy);

                if (sticky < minSticky)
                {
                    minSticky = sticky;
                    bestModel = model;
                }
                Result result1 = new Result();
                result1.Root0 = root[0].ToString();
                result1.Root1 = root[1].ToString();
                result1.Function = function;
                result1.Residual = sticky.ToString();
                result.Add(result1);
            }

            if (bestModel != null)
            {
                double[][] listSqurel = bestModel.Suma(x, y);
                root = gaussianMethod.Gauss(listSqurel);
                function = bestModel.StringFunction(root[0], root[1]);
            }
            return  result;
        }
        private double calculationSticky(List<double> y, List<double> calculatedy)
        {
            double sticky = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sticky += Math.Pow(Math.Abs(y[i]) - Math.Abs(calculatedy[i]), 2);
            }
            return sticky;
        }

        public void PlotBestModel(PlotModel model)
        {
            if (bestModel != null)
            {
                LineSeries lineSeries = new LineSeries
                {
                    Title = "Best Fit Model",
                    Color = OxyColors.Blue,
                    StrokeThickness = 2
                };

                //var scatterSeries = new ScatterSeries
                //{
                //    Title = "Точки",
                //    MarkerType = MarkerType.Triangle,
                //    MarkerSize = 4
                //};

                for (double xi = 0; xi <= 100000; xi += 0.5)
                {
                    double yi = bestModel.Function(root[0], root[1], xi);
                    lineSeries.Points.Add(new DataPoint(xi, yi));
                  
                }

                model.Series.Add(lineSeries);
                
            } 
        }


    }
}
