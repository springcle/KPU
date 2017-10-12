using Offline.Dialog;
using Offline.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Offline.Frame.Test
{
    /// <summary>
    /// TestGuide.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestGuide : BaseFrame
    {
        public TestGuide():base("TestGuide")
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SerialCommunicationManager.getInstance.connect(PortConnectDialog.PortName);
            FrameManager.GetInstance.LoadFrame(FrameName.Meditaion);
          
        }
    }
}
