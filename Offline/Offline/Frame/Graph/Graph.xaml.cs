using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Offline.Frame.Graph
{
    /// <summary>
    /// Graph.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Graph : UserControl
    {
        public Graph()
        {
            InitializeComponent();

            SetupChartProperties();
        }

        private void SetupChartProperties()
        {
            //customize the X-Axis to properly display Time 
            chart1.Series.Clear(); //first remove all series completely

            //// Enable all elements
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 50;

            // Set Grid lines and tick marks interval
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 100;
            chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 30;
            //chart1.ChartAreas[0].AxisX.MajorGrid.IntervalOffsetType = DateTimeIntervalType.Seconds;
            //chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 5;
            ///lchart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 5;

            //// Set Line Color
            //chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Blue;

            //// Set Line Style
            //chart1.ChartAreas[0].AxisX.MajorTickMark.LineDashStyle = ChartDashStyle.Solid;

            //// Set Line Width
            //chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;    


            chart1.ChartAreas[0].AxisX.Interval = 20; //let's show a minute of data
            chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart1.ChartAreas[0].AxisX.Minimum = 0;

            //set legend position and properties as required
            chart1.Legends[0].LegendStyle = LegendStyle.Table;

            // Set table style if legend style is Table
            chart1.Legends[0].TableStyle = LegendTableStyle.Wide;

            // Set legend docking
            chart1.Legends[0].Docking = Docking.Top;

            // Set legend alignment
            chart1.Legends[0].Alignment = StringAlignment.Center;

            // Set Antialiasing mode
            //this can be set lower if there are any performance issues!
            chart1.AntiAliasing = AntiAliasingStyles.None;
            chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
        }

        public void CheckAndAddSeriesToGraph(string strPinDescription, string strUnit)
        {
            foreach (Series se in chart1.Series)
            {
                if (se.Name == strPinDescription)
                {
                    return; //already exists
                }
            }
            Series s = chart1.Series.Add(strPinDescription);
            s.ChartType = SeriesChartType.FastLine;
            s.BorderColor = System.Drawing.Color.FromArgb(255, 0, 0, 105);
            s.BorderWidth = 0; // show a THICK line for high visibility, can be reduced for high volume data points to be better visible
            s.ShadowOffset = 0;
            s.IsVisibleInLegend = false;
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.NotSet;

            //s.IsValueShownAsLabel = true;                       
            // s.LegendText = strPinDescription + " (" + strUnit + ")";
            //   s.LegendToolTip = strPinDescription + " (" + strUnit + ")";
        }

        internal void ClearSeriesFromGraph()
        {
            //remove the series curve itself
            chart1.Series.Clear();
        }

        internal void ClearCurveDataPointsFromGraph()
        {
            //clear only DATA points from curve, keeping it as is.
            foreach (Series s in chart1.Series)
            {
                s.Points.Clear();
            }
        }

        public void AddPointToLine(string strPinName, double dValueY, double dValueX)
        {
            // we don't want series to be drawn while adding points to it.
            //this can reduce flicker.
            chart1.Series.ResumeUpdates();
            chart1.Series[strPinName].Points.AddXY(dValueX, dValueY);
            chart1.Series.ResumeUpdates();
        }

        private void UserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            chart1.Width = (int)e.NewSize.Width;
            chart1.Height = (int)e.NewSize.Height;
        }
    }
}
