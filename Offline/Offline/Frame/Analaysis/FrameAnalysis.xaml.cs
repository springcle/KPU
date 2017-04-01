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
    /// Interaction logic for FrameAnalysis.xaml
    /// </summary>
    public partial class FrameAnalysis : BaseFrame
    {
        public FrameAnalysis():base("FrameAnalysis")
        {
            InitializeComponent();
            SerialCommunicationManager.getInstance.writeData();
        }
        private void Analysis_success(object sender, RoutedEventArgs e)
        {
            FrameManager.GetInstance.LoadFrame(FrameName.FrameAnalysisResult);
        }
    }
}
