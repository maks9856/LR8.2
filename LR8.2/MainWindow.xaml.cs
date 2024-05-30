using OxyPlot;
using OxyPlot.Series;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LR8._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<double> xi = new List<double> { 1, 1.3, 1.6, 1.9, 2.2, 2.5, 2.8, 3.1, 3.4, 3.7, 4, 4.3, 4.6, 4.9, 5.2, 5.5, 5.8, 6.1, 6.4, 6.7, 7, 7.3, 7.6, 7.9, 8.2, 8.5, 8.8, 9.1, 9.4, 9.7, 10, 10.3, 10.6, 10.9, 11.2 };
        public List<double> yi = new List<double>() { -0.8, 0.3, 1.1, 1.8, 2.4, 2.9, 3.3, 3.8, 4.1, 4.5, 4.8, 5.1, 5.3, 5.6, 5.8, 6, 6.3, 6.5, 6.7, 6.8, 7, 7.2, 7.3, 7.5, 7.6, 7.8, 7.9, 8.1, 8.2, 8.3, 8.4, 8.6, 8.7, 8.8, 8.9 };
        public PlotModel MyModel { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            MyModel = new PlotModel { Title = "Приклад графіка" };
            CreateScatterSeries();
            DataContext = this;
        }
        private void CreateScatterSeries()
        {
            var scatterSeries = new ScatterSeries
            {
                Title = "Точки",
                MarkerType = MarkerType.Triangle,
                MarkerSize = 4
            };

            for(int i = 0; i < xi.Count; i++) 
            { 
            scatterSeries.Points.Add(new ScatterPoint(xi[i], yi[i]));
            
            }

            MyModel.Series.Add(scatterSeries);
        }
    }
}