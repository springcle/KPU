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
using MahApps.Metro.Controls;
using Offline.Dialog;
using Offline.Frame;
using Offline.Frame.Analaysis;
using Offline.Frame.Calibration;
using Offline.Manager;

namespace Offline
{//
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
            CreateLogInDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Initialize()
        {
            FrameManager.GetInstance.Frame = Frame;
            FrameManager.GetInstance.AddeFrame(new FrameMenu());
            FrameManager.GetInstance.AddeFrame(new FrameAnalysisSurvey());
            FrameManager.GetInstance.AddeFrame(new GuidLine());
            FrameManager.GetInstance.AddeFrame(new FrameAnalysisResult());
            FrameManager.GetInstance.AddeFrame(new FrameAnalysis());
            FrameManager.GetInstance.AddeFrame(new EOGCalibration());
        }

        private void CreateLogInDialog()
        {
            var win = new LoginDialog();
            win.Owner = this;
            win.ShowDialog();
            if (win.DialogResult.HasValue && win.DialogResult.Value == true)
            {
                //로그인 성공 시
                FrameManager.GetInstance.LoadFrame(FrameName.EOGCalibration);

            }
            else if (win.DialogResult.HasValue && win.DialogResult.Value == false)
            {
                MessageBox.Show("로그인 실패");
            }
        }
    }
}
