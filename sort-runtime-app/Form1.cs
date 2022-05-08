using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using System.Drawing.Imaging;

namespace sort_runtime_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCartesianChartAppearance();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetCartesianChartAppearance()
        {
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "\nSize of array, items",
                //Labels = lab,
                IsMerged = false,
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),


                LabelFormatter = val => Convert.ToString(Convert.ToInt32(val) * 1000),
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Step = 1,
                    StrokeDashArray = new DoubleCollection(1),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(132, 154, 164))
                }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Time executed, milliseconds\n ",
                MinValue = 0,
                IsMerged = false,
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),
                Separator = new Separator
                {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new DoubleCollection(4),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(132, 154, 164))

                }
            });

            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Top;
            cartesianChart1.DefaultLegend.FontSize = 12;
        }
    }
}
