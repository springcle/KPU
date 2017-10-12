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
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace Offline.Dialog
{
    /// <summary>
    /// Interaction logic for PortConnectDialog.xaml
    /// </summary>
    public partial class PortConnectDialog : Window
    {
        bool isConnecting =false;
        public static string PortName;
        public PortConnectDialog()
        {
            InitializeComponent();
            FindPort();
        }
        private void port_ok(object sender, RoutedEventArgs e)
        {
            if (isConnecting) { return; }
            Connect();
        }
        private void Connect()
        {
            isConnecting = true;
            string item = comboBox.SelectedItem as string;
            if (item == null) { MessageBox.Show("포트를 선택해주세요"); return; }
            PortName = item.Trim();
            isConnecting = false;
            this.Close();
        }

        private void FindPort()
        {
            string[] ports = SerialCommunicationManager.FindPorts();
            foreach (var each in ports)
            {
                comboBox.Dispatcher.Invoke(() => { comboBox.Items.Add(each); });
            }
        }
    }
}


