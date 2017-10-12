using System.Windows;
using Offline.Frame;
using Offline.Frame.Analaysis;
using Offline.Manager;
using Offline.Dialog;
using System;
using System.IO.Pipes;
using System.Diagnostics;
using System.Text;

namespace Offline.Frame
{
    /// <summary>
    /// FrameMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FrameMenu : BaseFrame
    {
        bool isGamePlaying = true;
        String selectGameURL = String.Empty;
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
           new ENVDialog().Show();
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
            selectGameURL = @"C:\Users\AJ\Desktop\FlyingBallon.exe";
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
            catch (Exception error)
            {
                MessageBox.Show("게임 종료");
            }
            finally
            {
                SerialCommunicationManager.getInstance.disConnect();
                pipeServer.Close();
            }
            //Window win = new TrainingSelectDialog();
            //win.ShowDialog();
        }

        private void M_AppProcess_Exited(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    
}
