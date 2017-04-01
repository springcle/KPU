using System.Windows;
using Offline.Frame;
using Offline.Frame.Analaysis;
using Offline.Manager;
using Offline.Dialog;

namespace Offline.Frame
{
    /// <summary>
    /// FrameMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FrameMenu : BaseFrame
    {
        public FrameMenu():base("FrameMenu")
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Char_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MachineLearning_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrainAnalysis_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.GetInstance.LoadFrame(FrameName.FrameAnalysisSurvey);
        }

        private void BrainTraning_Click(object sender, RoutedEventArgs e)
        {

        }
    
    }
}
