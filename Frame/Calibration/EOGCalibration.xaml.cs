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
using Offline.Dialog;

namespace Offline.Frame.Calibration
{
    /// <summary>
    /// EOGCalibration.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EOGCalibration : BaseFrame
    {
        Random rand = new Random();
  

        public EOGCalibration() : base("EOGCalibration")
        {
            InitializeComponent();
            blurBackground.Background.Opacity = 0.65f;
            infomationText.Foreground.Opacity = 1f;
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
        public async void CalibrationRoutine()
        {
            //안내문구 애니메이션
            Action<string,float> infomation = (message,time) =>
            {
                OfflineTimer timer = new OfflineTimer();
                timer.start();
                float direction = 1;
                float rate = 0.05f;
                float min = 0.15f;
                float max = 0.85f;
                infomationText.Dispatcher.Invoke(() => {
                    infomationText.Visibility = Visibility.Visible;
                    infomationText.Opacity = max;
                    infomationText.Text = message;
                });
                blurBackground.Dispatcher.Invoke(() => blurBackground.Visibility = Visibility.Visible);
                while (timer.currentTime.Seconds <= time)
                {
                   
                    infomationText.Dispatcher.Invoke(() =>
                    {
                      
                        double opacity = 0;
                        infomationText.Foreground.Opacity += rate * direction;
                        infomationText.Dispatcher.Invoke(() => opacity = infomationText.Foreground.Opacity);
                        if (opacity <= min) direction = 1;
                        else if (opacity >= max) direction = -1;
                    });
                    Thread.Sleep(50);
                }
                infomationText.Dispatcher.Invoke(() =>
                {
                    infomationText.Opacity = 0f;
                    blurBackground.Visibility = Visibility.Hidden;
                    infomationText.Text = string.Empty;
                });
            };
            //인트로
            await Task.Run(() => infomation("잠시 후 뇌파 측정을 시작합니다.", 1.5f));
            await Task.Run(() => infomation("안내 문구에 따라 진행해주세요.", 0.75f));


            Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Visible);
            await Task.Delay(5000);
            var result = MessageBox.Show("설명을 듣겠습니까?", "Question",
            MessageBoxButton.YesNo, MessageBoxImage.Information);
            Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Hidden);

            //설명 보기
            if (result == MessageBoxResult.Yes)
            {

                await Task.Run(() => infomation("좌측은 뇌파 그래프입니다.", 1.5f));
                await Task.Run(() => infomation("차례대로", 1.5f));
                await Task.Run(() => infomation("각 1체널 부터 8체널까지", 1f));
                await Task.Run(() => infomation("뇌활성도를 보여줍니다.", 1f));
                await Task.Run(() => infomation("우측은", 1f));
                await Task.Run(() => infomation("설정창입니다.", 1f));
                await Task.Run(() => infomation("차례대로", 1.5f));
                await Task.Run(() => infomation("눈깜빡임 감지", 0.75f));
                await Task.Run(() => infomation("파일패스", 0.75f));
                await Task.Run(() => infomation("노치필터", 0.75f));
                await Task.Run(() => infomation("필터", 0.75f));
                await Task.Run(() => infomation("스케일링비율을 보여줍니다.", 1f));
                //
            }
            //      
            //기기 연결
            await Task.Run(() => infomation("지금부터 기기 연결을 시작하겠습니다.", 1.5f));
            try
            {
                await Task.Run(() => 
                {
                    graph.OpenPort(PortConnectDialog.PortName);
                    graph.StartStreming();
                });
            }
            catch (Exception e)
            {
                await Task.Run(() => infomation("기기 연결에 실패하셨습니다.", 1.5f));
                await Task.Run(() => infomation(e.Message, 1.5f));
                await Task.Run(() => infomation("다시 확인하고 실행해주세요.", 1.5f));
                
                FrameManager.GetInstance.LoadFrame(FrameName.GuidLine);
            }
         
            await Task.Run(() => infomation("기기 연결이 완료되었습니다.", 1.5f));
            //칼레브레이션
            await Task.Run(() => infomation("장치가 안정화 될 때까지 기다려주세요.", 1.5f));
            Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Visible);
            await Task.Delay(3000);
            Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Hidden);
            await Task.Run(() => infomation("이제 칼리브레이션을 하겠습니다.", 1.5f));
            await Task.Run(() => infomation("그래프가 다시 나타나면", 1.0f));
            await Task.Run(() => infomation("눈을 한번만 깜빡여주세요.", 1.5f));
            Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Visible);

            await Task.Run(()=>
            {
                OfflineTimer timer = new OfflineTimer();
                timer.start();
                graph.BLINKED = 0;
                while (graph.BLINKED <1)
                {
                    if (timer.currentTime.Seconds > 5)
                    {
                        Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Visible);
                        result = MessageBox.Show("기기를 다시 확인하고 연결해주세요","안내",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        FrameManager.GetInstance.LoadFrame(FrameName.GuidLine);
                    }
                }
            });
            Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Hidden);
            await Task.Run(() => infomation("다시 한번 해보겠습니다.", 1.5f));
            await Task.Run(() => infomation("그래프가 다시 나타나면", 1.0f));
            await Task.Run(() => infomation("눈을 천천히 세번 깜빡여주세요.", 1.5f));
            Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Visible);

            await Task.Run(() =>
            {
                OfflineTimer timer = new OfflineTimer();
                timer.start();
                graph.BLINKED = 0;
                while (graph.BLINKED < 4)
                {
                    if (timer.currentTime.Seconds > 10)
                    {
                        Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Visible);
                        result = MessageBox.Show("기기를 다시 확인하고 연결해주세요", "안내",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        FrameManager.GetInstance.LoadFrame(FrameName.GuidLine);
                    }
                }
            });
            Graph.Dispatcher.Invoke(() => Graph.Visibility = Visibility.Hidden);
            await Task.Run(() => infomation("칼리브레이션을 모두 마쳤습니다.", 1.5f));

            await Task.Run(() => infomation("본격적으로 검사를 시작하겠습니다.", 1.5f));
            await Task.Run(() => infomation("안내 문구에 따라 진행해주세요.", 0.75f));

            //검사 하기 집중도 - > 명상도 -> 좌우뇌 활성도

            //집중도는 TMT

            //명상도는 명상

            //좌우뇌 활성도

            FrameManager.GetInstance.LoadFrame(FrameName.TestGuide);

        }


        public override void OnUnLoaded()
        {
            graph.ClosePort();
        }

       

    }
}

