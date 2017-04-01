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
        bool isConnecting;
        public PortConnectDialog()
        {
            InitializeComponent();
            FindPort();


        }
        private void port_ok(object sender, RoutedEventArgs e)
        {
            if (isConnecting)  { return; }
            Connect();

        }
        private void Connect()
        {
            isConnecting = true;
            SerialCommunicationManager.getInstance.init();
            string item = comboBox.SelectedItem as string;
            if (item == null) { MessageBox.Show("포트를 선택해주세요"); return; }
            item.Trim();
            Thread connect = new Thread(new ThreadStart(() =>
            {
                if (SerialCommunicationManager.getInstance.isOpen)
                {
                    MessageBox.Show("이미 연결 상태입니다.");
                    return;
                }

                Loading.Dispatcher.Invoke( ()=>Loading.Visibility=Visibility.Visible, DispatcherPriority.Normal);
                try
                {
                    SerialCommunicationManager.getInstance.connect(item);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    Loading.Dispatcher.Invoke(() => {

                        Loading.Visibility = Visibility.Hidden;
                        isConnecting = false;
                        if(SerialCommunicationManager.getInstance.isOpen)
                        FrameManager.GetInstance.LoadFrame(FrameName.EOGCalibration);
                        this.Close();
                    }, DispatcherPriority.Normal);
                }
              
            }));
            connect.IsBackground = true;
            connect.Start();
        }


        private void FindPort()
        {
            string[] ports = SerialCommunicationManager.getInstance.FindPorts();
            foreach (var each in ports)
            {
                comboBox.Dispatcher.Invoke(() => { comboBox.Items.Add(each); });
            }
        }
    }
}


