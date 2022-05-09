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
using System.Text.RegularExpressions;
using System.Threading;

namespace sort_runtime_app
{
    public partial class Form1 : Form
    {
        ChartValues<double> Val0 = new ChartValues<double> { };
        ChartValues<double> Val1 = new ChartValues<double> { };
        ChartValues<double> Val2 = new ChartValues<double> { };
        ChartValues<double> Val3 = new ChartValues<double> { };

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

        private void button2_Click(object sender, EventArgs e)
        {
            switch (panel1.Visible)
            {
                case true:
                    {
                        panel1.Visible = false;
                        break;
                    }
                case false:
                    {
                        panel1.Visible = true;
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                comboBox2.SelectedIndex = 0;
            }
            if (comboBox3.SelectedIndex == -1)
            {
                comboBox3.SelectedIndex = 0;
            }
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                checkedListBox1.SetItemChecked(3, true);
            }

            CreateGraph(checkedListBox1.GetItemChecked(0),
                checkedListBox1.GetItemChecked(1),
                checkedListBox1.GetItemChecked(2),
                checkedListBox1.GetItemChecked(3),
                Convert.ToInt32(Regex.Replace(comboBox2.SelectedItem.ToString(), " ", "")),
                Convert.ToInt32(Regex.Replace(comboBox3.SelectedItem.ToString(), " ", ""))
                );
        }

        private void CreateGraph(bool i0, bool i1, bool i2, bool i3, int size, int step)
        {
            int[] array = new int[size];
            Program.CreateArray(ref array);
            Stopwatch stopwatch = new Stopwatch();
            cartesianChart1.Series.Clear();

            Val0.Clear();
            Val1.Clear();
            Val2.Clear();
            Val3.Clear();

            if (i0)
            {
                cartesianChart1.Series.Add(new LineSeries
                {
                    Title = "Insertion sort",
                    Values = Val0,
                    StrokeThickness = 2,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(50),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(245, 127, 23)),
                    Fill = Brushes.Transparent,
                    LineSmoothness = 0,
                    PointGeometry = null
                });
            }
            if (i1)
            {
                cartesianChart1.Series.Add(new LineSeries
                {
                    Title = "Selection sort",
                    Values = Val1,
                    StrokeThickness = 2,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(50),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(183, 28, 28)),
                    Fill = Brushes.Transparent,
                    LineSmoothness = 0,
                    PointGeometry = null
                });
            }
            if (i2)
            {
                cartesianChart1.Series.Add(new LineSeries
                {
                    Title = "Bubble sort",
                    Values = Val2,
                    StrokeThickness = 2,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(50),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(51, 105, 30)),
                    Fill = Brushes.Transparent,
                    LineSmoothness = 0,
                    PointGeometry = null
                });
            }
            if (i3)
            {
                cartesianChart1.Series.Add(new LineSeries
                {
                    Title = "C# sort",
                    Values = Val3,
                    StrokeThickness = 2,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(50),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(26, 122, 192)),
                    Fill = Brushes.Transparent,
                    LineSmoothness = 0,
                    PointGeometry = null
                });
            }


            for (int i = 0; i <= size; i += step)
            {
                if (i0)
                {
                    stopwatch.Start();
                    Program.InsertionSort(array.Take(i).ToArray());
                    stopwatch.Stop();
                    Val0.Add(stopwatch.ElapsedMilliseconds);
                    stopwatch.Reset();
                }
                if (i1)
                {
                    stopwatch.Start();
                    Program.SelectionSort(array.Take(i).ToArray());
                    stopwatch.Stop();
                    Val1.Add(stopwatch.ElapsedMilliseconds);
                    stopwatch.Reset();
                }
                if (i2)
                {
                    stopwatch.Start();
                    Program.BubleSort(array.Take(i).ToArray());
                    stopwatch.Stop();
                    Val2.Add(stopwatch.ElapsedMilliseconds);
                    stopwatch.Reset();
                }
                if (i3)
                {
                    int[] arr = array.Take(i).ToArray();
                    stopwatch.Start();
                    Array.Sort(arr);
                    stopwatch.Stop();
                    Val3.Add(stopwatch.ElapsedMilliseconds);
                    stopwatch.Reset();
                }

                cartesianChart1.Update();
            }
        }
    }
}
