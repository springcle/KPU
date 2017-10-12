using Offline.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Offline.Frame.Analaysis
{
    /// <summary>
    /// Interaction logic for FrameAnalysisResult.xaml
    /// </summary>
    public partial class FrameAnalysisResult : BaseFrame
    {
        public FrameAnalysisResult() : base("FrameAnalysisResult")
        {
            InitializeComponent();
        }
        public override void OnLoaded()
        {
            initIndicator();
        }
        private void Analysis_reuslt_ok(object sender, RoutedEventArgs e)
        {
            FrameManager.GetInstance.LoadFrame(FrameName.FrameMenu);
        }
        private void initIndicator()
        {
            meditation_bad.Opacity = 0.1f;
            meditation_bad_image.Opacity = 0.1f;
            meditation_normal.Opacity = 0.1f;
            meditation_normal_image.Opacity = 0.1f;
            meditation_good.Opacity = 0.1f;
            meditation_good_image.Opacity = 0.1f;
            concentration_bad.Opacity = 0.1f;
            concentration_bad_image.Opacity = 0.1f;
            concentration_normal.Opacity = 0.1f;
            concentration_normal_image.Opacity = 0.1f;
            concentration_good.Opacity = 0.1f;
            concentration_good_image.Opacity = 0.1f;
            if (Test.ResultLoading.sendMeditation >= 0.45 || Test.ResultLoading.sendMeditation <= 0.525)
            {
                meditation_normal.Opacity = 1f;
                meditation_normal_image.Opacity = 1f;
            }
            else if (Test.ResultLoading.sendMeditation < 0.45)
            {
                meditation_bad.Opacity = 1f;
                meditation_bad_image.Opacity = 1f;
            }
            else
            {
                meditation_good.Opacity = 1f;
                meditation_good_image.Opacity = 1f;
            }
            if (Test.ResultLoading.sendConcentration >= 0.44 || Test.ResultLoading.sendConcentration <= 0.5)
            {
                concentration_normal.Opacity = 1f;
                concentration_normal_image.Opacity = 1f;
            }
            else if (Test.ResultLoading.sendConcentration < 0.44)
            {
                concentration_bad.Opacity = 1f;
                concentration_bad_image.Opacity = 1f;
            }
            else
            {
                concentration_good.Opacity = 1f;
                concentration_good_image.Opacity = 1f;
            }
            brain_left.Dispatcher.Invoke(() => brain_left.Text = ((int)(Test.ResultLoading.brainLR*100)).ToString());
            brain_right.Dispatcher.Invoke(() => brain_right.Text = (100-(int)(Test.ResultLoading.brainLR * 100)).ToString());
            loadGraphData();
        }
        private void loadGraphData()
        {
            List<double> trend_concentration = new List<double>();
            List<double> trend_meditation = new List<double>();
            double medi_max, medi_min, concen_max, concen_min;
            medi_max = Test.ResultLoading.meditationTrend.Max();
            medi_min = Test.ResultLoading.meditationTrend.Min();
            concen_max = Test.ResultLoading.concentrationTrend.Max();
            concen_min = Test.ResultLoading.concentrationTrend.Min();
            for (int i = 0; i < Test.ResultLoading.meditationTrend.Count; i++)
            {
                trend_meditation.Add(0);
                trend_concentration.Add(0);
            }
            for (int i =0; i<Test.ResultLoading.meditationTrend.Count; i++)
            {
                trend_concentration[i] = (Test.ResultLoading.concentrationTrend[i] - concen_min) / (concen_max - concen_min) * 100;
                trend_meditation[i] = (Test.ResultLoading.meditationTrend[i] - medi_min) / (medi_max - medi_min) * 100;
            }
            Graph.GraphTrend mediGraph = new Graph.GraphTrend();
            Graph.GraphTrend concenGraph = new Graph.GraphTrend();
            mediGraph.init(trend_meditation, trend_meditation.Count);
            concenGraph.init(trend_concentration, trend_concentration.Count);
            meditationTrendGraph.Child = mediGraph;
            concentrarionTrendGraph.Child = concenGraph;
        }
    }
}