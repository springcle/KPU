using Offline.Manager;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Windows;


namespace Offline.Dialog
{
    /// <summary>
    /// Interaction logic for TrainingSelectDialog.xaml
    /// </summary>
    public partial class TrainingSelectDialog : Window
    {
        bool isGamePlaying = true;
        String selectGameURL = String.Empty;
        public TrainingSelectDialog()
        {
            InitializeComponent();
        }

        private void sustainButton_Click(object sender, RoutedEventArgs e)
        {
            selectGameURL = @"C:\Users\AJ\Desktop\FlyingBallon.exe";
        }

        private void reinforceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void complexButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {

            if (selectGameURL == String.Empty)
            {
                MessageBox.Show("게임을 선택해주세요");
                return;
            }

            new PortConnectDialog().ShowDialog();
            var pipeServer = new NamedPipeServerStream(
                "serialPipe", PipeDirection.Out, 1);
            try
            {
                SerialCommunicationManager.getInstance.connect(PortConnectDialog.PortName);
                SerialCommunicationManager.getInstance.startStreming();

                var info = new ProcessStartInfo(selectGameURL);
                info.UseShellExecute = true;
                info.WindowStyle = ProcessWindowStyle.Maximized;
                var m_AppProcess = Process.Start(info);
                m_AppProcess.Exited += M_AppProcess_Exited;

                

                pipeServer.WaitForConnection();
                while (isGamePlaying)
                {
                    string str = SerialCommunicationManager.getInstance.currentData;
                    if (str == string.Empty) str = "not connect";
                    byte[] outBuffer = Encoding.Unicode.GetBytes(str);
                    int len = outBuffer.Length;
                    pipeServer.WriteByte((byte)(len / 256));
                    pipeServer.WriteByte((byte)(len % 256));
                    pipeServer.Write(outBuffer, 0, len);
                    pipeServer.Flush();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                SerialCommunicationManager.getInstance.disConnect();
                pipeServer.Close();
            }
        }

        private void M_AppProcess_Exited(object sender, EventArgs e)
        {
            isGamePlaying = false;
        }
    }
}


