using Offline.Manager;
using Offline.Properties;
using Offline.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Meditaion.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Meditaion : BaseFrame
    {
        private SoundPlayer Player = new SoundPlayer();
      
        public Meditaion():base("Meditaion")
        {
            InitializeComponent();
            blurBackground.Background.Opacity = 0.65f;
            infomationText.Foreground.Opacity = 1f;
        }
        /** OnLoaded **/
        public override void OnLoaded()
        {
            startAudio();
        }
        public async void startAudio()
        {
            try
            {
                // Note: You may need to change the location specified based on
                // the sounds loaded on your computer.
                //       this.Player.SoundLocation = @"C:\Windows\Media\chimes.wav";
                //     this.Player.PlayLooping();
                //안내문구 애니메이션
                Action<string, float> infomation = (message, time) =>
                {
                    OfflineTimer timer = new OfflineTimer();
                    timer.start();
                    float direction = 1;
                    float rate = 0.05f;
                    float min = 0.15f;
                    float max = 0.85f;
                    infomationText.Dispatcher.Invoke(() =>
                    {
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
                SerialCommunicationManager.getInstance.startStreming();
                await Task.Run(() => infomation("잠시 후 명상도 측정을 시작합니다.", 1.5f));
                await Task.Run(() => infomation("10초간 꽃을 쳐다봐주세요.", 1.5f));
                flower.Dispatcher.Invoke(() => flower.Visibility = Visibility.Visible);
                await Task.Run(() => infomation("IDLE", 10f));
                flower.Dispatcher.Invoke(() => flower.Visibility = Visibility.Hidden);

                await Task.Run(() => infomation("음악이 진행되는 동안 눈을 감고", 1.5f));
                await Task.Run(() => infomation("편안한 상태로 진행해주세요.", 1.5f));
                await Task.Run(() => infomation("음악이 종료되면 눈을 뜨시면 됩니다.", 1.5f));
                await Task.Run(() => infomation("시작하겠습니다.", 2f));

                System.IO.Stream str = Properties.Resources.medi;
                SoundPlayer snd = new SoundPlayer(str);
                snd.Play();
                await Task.Run(() => infomation("명상중.", 58f));
                snd.Stop();
                await Task.Run(() => infomation("10초간 꽃을 쳐다봐주세요.", 1.5f));
                flower.Dispatcher.Invoke(() => flower.Visibility = Visibility.Visible);
                await Task.Run(() => infomation("IDLE", 10f));
                flower.Dispatcher.Invoke(() => flower.Visibility = Visibility.Hidden);

                await Task.Run(() => infomation("명상도 측정이 완료되었습니다.", 3f));

                //집중도로 이동
                SerialCommunicationManager.getInstance.stopStreming();
                FrameManager.GetInstance.LoadFrame(FrameName.TMT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }
        }

        public void stopAudio()
        {
            this.Player.Stop();
        }
    }
}
