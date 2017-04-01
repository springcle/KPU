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
using Offline.Manager;
using Offline.Dialog;

namespace Offline.Frame.Calibration
{
    /// <summary>
    /// GuidLine.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GuidLine : BaseFrame
    {
        public GuidLine():base("GuidLine")
        {
            InitializeComponent();
        }
        private void test_start_click(object sender, RoutedEventArgs e)
        {
            Window win = new PortConnectDialog();
            win.ShowDialog();
        }
    }
}
