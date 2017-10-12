using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Offline.Frame.Graph
{
    public partial class GraphTrend : UserControl
    {

        public GraphTrend()
        {
            InitializeComponent();
        }
        public void init(List<double> trend, int timeCount)
        {
            chart1.Series.Clear();
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Name = "";
            for (int i = 0; i < trend.Count; i++)
            {
                series.Points.Add(trend[i]);
            }
            series.IsVisibleInLegend = false;
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart1.ChartAreas[0].AxisX.LineColor = Color.Black;
            chart1.Width = 550;
            chart1.Height = 280;
            chart1.Series.Add(series);
            // y축 하나 씩 값 대입

        }
       
    }
}
