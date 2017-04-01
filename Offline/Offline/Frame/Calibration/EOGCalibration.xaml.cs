using Offline.Manager;
using System;
using System.Windows;
using System.Windows.Threading;
using Offline.Utilities;
using Offline.DataStructure;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace Offline.Frame.Calibration
{
    /// <summary>
    /// EOGCalibration.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EOGCalibration : BaseFrame
    {
        float interval = 8f;
        DateTime timeStarted;
        double yValue = 2;
        double dVariance = 0;
        Random rand = new Random();
        DispatcherTimer timer = new DispatcherTimer();

        public EOGCalibration() : base("EOGCalibration")
        {
            InitializeComponent();
            //안내문구 (잠시 기다려주세요) 
            blurBackground.Background.Opacity = 0.65f;
            infomationText.Foreground.Opacity = 1f;
            graph_fp1.Visibility = Visibility.Hidden;
            graph_fp2.Visibility = Visibility.Hidden;
            timer.Tick += Timer_Tick;
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            //    if (!SerialCommunicationManager.getInstance.isOpen) return;
            var data = rand.NextDouble();
            double dValueX = (double)(DateTime.Now.Subtract(timeStarted).TotalSeconds);
            graph_fp1.Dispatcher.Invoke(() => graph_fp1.AddPointToLine("chanel1", rand.NextDouble() + (data - dVariance), dValueX * interval));
        }

        private void calibration_next_click(object sender, RoutedEventArgs e)
        {
            FrameManager.GetInstance.LoadFrame(FrameName.FrameAnalysis);
        }

        /** OnLoaded **/
        public override void OnLoaded()
        {
            CalibrationRoutine();

        }



        /** 안내문구 및 EEG Data 저장 **/
        public void CalibrationRoutine()
        {
            bool isLoading = true;
            EEG eeg;
            //안내문구 애니메이션
            Action infomation = () =>
            {
                OfflineTimer timer = new OfflineTimer();
                timer.start();
                float direction = 1;
                float rate = 0.05f;
                float min = 0.15f;
                float max = 0.85f;
                while (timer.currentTime.Seconds <= 1)
                {
                    infomationText.Dispatcher.Invoke(() => infomationText.Foreground.Opacity += rate * direction);
                    double opacity = 0;
                    infomationText.Dispatcher.Invoke(() => opacity = infomationText.Foreground.Opacity);
                    if (opacity <= min) direction = 1;
                    else if (opacity >= max) direction = -1;
                    Thread.Sleep(50);
                }
                infomationText.Dispatcher.Invoke(() =>
                {
                    infomationText.Opacity = 0f;
                    infomationText.Text = string.Empty;
                    infomationText.Visibility = Visibility.Hidden;
                });
                blurBackground.Dispatcher.Invoke(() => blurBackground.Visibility = Visibility.Hidden);
                graph_fp1.Dispatcher.Invoke(() => graph_fp1.Visibility = Visibility.Visible);
                graph_fp2.Dispatcher.Invoke(() => graph_fp2.Visibility = Visibility.Visible);
                isLoading = false;
                GraphDraw();
            };

            // 5초간 데이터 받아오기
            Action initData = () =>
            {
                OfflineTimer timer = new OfflineTimer();
                timer.start();
                while (isLoading)
                {
                    var data = SerialCommunicationManager.getInstance.data;
                    eeg = new EEG(data);
                    DataManager.getInstance.add(eeg);
                }
            };

            //받은 데이터 정규화
            Action nomalize = () =>
            {

            };

            //안내문구 ( 눈을 크게 깜빡여주세요. )
            Action eyesBlinkOnce = () =>
            {
                infomationText.Text = "눈을 크게 깜빡여주세요.";
                infomationText.Foreground.Opacity = 1f;
                infomationText.Visibility = Visibility.Visible;

                OfflineTimer timer = new OfflineTimer();
                timer.start();
                float direction = 1;
                float rate = 0.05f;
                float min = 0.25f;
                float max = 0.75f;
                // Eye Blinking 데이터 받을 동안만 쓰레드 실행
                EegPattern eegPattern = new EegPattern();
                while (timer.currentTime.Seconds <= 5)
                {
                    infomationText.Foreground.Opacity = 1f;
                    infomationText.Dispatcher.Invoke(() => infomationText.Foreground.Opacity += rate * direction);
                    double opacity = 0;
                    infomationText.Dispatcher.Invoke(() => opacity = infomationText.Foreground.Opacity);
                    if (opacity <= min) direction = 1;
                    else if (opacity >= max) direction = -1;
                    Thread.Sleep(50);
                }
                infomationText.Dispatcher.Invoke(() =>
                {
                    infomationText.Opacity = 0f;
                    infomationText.Text = string.Empty;
                    infomationText.Visibility = Visibility.Hidden;
                });
            };
            //눈 크게 감빡임 값 저장

            //안내문구 ( 눈을 두 번 깜빡여주세요. )
            Action eyesBlinkTwice = () =>
            {
                infomationText.Text = "눈을 두 번 깜빡여주세요.";
                infomationText.Foreground.Opacity = 1f;
                infomationText.Visibility = Visibility.Visible;

                OfflineTimer timer = new OfflineTimer();
                timer.start();
                float direction = 1;
                float rate = 0.05f;
                float min = 0.25f;
                float max = 0.75f;
                // Eye Blinking 데이터 2번 받을 동안만 쓰레드 실행
                while (timer.currentTime.Seconds <= 5)
                {
                    infomationText.Foreground.Opacity = 1f;
                    infomationText.Dispatcher.Invoke(() => infomationText.Foreground.Opacity += rate * direction);
                    double opacity = 0;
                    infomationText.Dispatcher.Invoke(() => opacity = infomationText.Foreground.Opacity);
                    if (opacity <= min) direction = 1;
                    else if (opacity >= max) direction = -1;
                    Thread.Sleep(50);
                }
                infomationText.Dispatcher.Invoke(() =>
                {
                    infomationText.Opacity = 0f;
                    infomationText.Text = string.Empty;
                    infomationText.Visibility = Visibility.Hidden;
                });

            };
            //두번 깜빡이면 -> 다음 검사화면으로 이동
            Task.Run(infomation);
            //Task.Run(initData);
        }

        private void GraphDraw()
        {
            if (timer != null && !timer.IsEnabled)
            {
                //SerialCommunicationManager.getInstance.writeData();
                graph_fp1.CheckAndAddSeriesToGraph("chanel1", "rpm");
                dVariance = yValue;
                timeStarted = DateTime.Now;
                timer.Interval = TimeSpan.FromMilliseconds(10);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }
        public override void OnUnLoaded()
        {
            if (timer != null && timer.IsEnabled)
                timer.Stop();
        }
    }
}
