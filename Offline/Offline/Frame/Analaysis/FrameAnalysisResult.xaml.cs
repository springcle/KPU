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
        private void Analysis_reuslt_ok(object sender, RoutedEventArgs e)
        {
            FrameManager.GetInstance.LoadFrame(FrameName.FrameMenu);
        }
    }
}