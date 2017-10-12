using Offline.Manager;
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
    /// TMT.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TMT : BaseFrame
    {

        bool isTMTComplete=false;
        public struct CircleButton
        {
            public Grid grid;
            public TextBlock textBlock;
        }
        List<CircleButton> buttonList = new List<CircleButton>(); 
        List<string> anser = new List<string>();
        int gridNumber = 49;

        private SolidColorBrush onClickColor = new SolidColorBrush(Color.FromArgb(255, 47, 216, 162));
        private SolidColorBrush onFailColor = new SolidColorBrush(Color.FromArgb(155, 255, 0, 0));
        private SolidColorBrush onEnterColor = new SolidColorBrush(Color.FromArgb(150, 47, 216, 162));
        private SolidColorBrush onIdelColor = new SolidColorBrush(Color.FromArgb(255, 188, 230, 216));

        public TMT():base("TMT")
        {
            InitializeComponent();
            random();
        }


        /** OnLoaded **/
        public override void OnLoaded()
        {
            startTMT();
        }

        async void  startTMT()
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
                Console.WriteLine("TMT 1");
                await Task.Run(() => infomation("잠시 후 집중도 측정을 시작합니다.", 1.5f));
                await Task.Run(() => infomation("10초간 꽃을 쳐다봐주세요.", 1.5f));
                flower.Dispatcher.Invoke(() => flower.Visibility = Visibility.Visible);
                await Task.Run(() => infomation("IDLE", 10f));
                flower.Dispatcher.Invoke(() => flower.Visibility = Visibility.Hidden);
                Console.WriteLine("TMT 2");
                await Task.Run(() => infomation("Trailing Making Test를 시행해주세요", 1.5f));
                Console.WriteLine("visiable");
                OfflineTimer offlineTimer = new OfflineTimer();
                offlineTimer.start();
                blurBackground.Dispatcher.Invoke(() => infomationText.Visibility = Visibility.Hidden);
                Console.WriteLine("waitStart");
                await Task.Run(
                () =>  {  while (!isTMTComplete) continue; });
                Console.WriteLine("waitEnd");
                blurBackground.Dispatcher.Invoke(() => infomationText.Visibility = Visibility.Hidden);
                ResultLoading.c_end = ResultLoading.c_start + offlineTimer.currentTime.Seconds;
                offlineTimer.stop();
                offlineTimer.start();
                Console.WriteLine("TMT 3");
                await Task.Run(() => infomation("10초간 꽃을 쳐다봐주세요.", 1.5f));
                flower.Dispatcher.Invoke(() => flower.Visibility = Visibility.Visible);
                await Task.Run(() => infomation("IDLE", 10f));
                flower.Dispatcher.Invoke(() => flower.Visibility = Visibility.Hidden);
                ResultLoading.c_finish = ResultLoading.c_end + offlineTimer.currentTime.Seconds;
                await Task.Run(() => infomation("집중도 측정이 완료되었습니다.", 3f));
                Console.WriteLine("TMT 4");
                //결과로 이동
                SerialCommunicationManager.getInstance.stopStreming();
                Console.WriteLine("TMT 5");
                IOManager.getInstance.Close();
                Thread.Sleep(500);
                FrameManager.GetInstance.LoadFrame(FrameName.ResultLoading);
                Console.WriteLine("TMT 6");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }
    }
      
        private void random()
        {
            var temp = createList();
            anser = createList();
            List<string> randomList = new List<string>();
            Random random = new Random();
            while (temp.Count > 0)
            {
                int index = random.Next(0, temp.Count - 1);
                randomList.Add(temp[index]);
                temp.RemoveAt(index);
            }
            var frame = Frame.Children;

            for (int cnt = 0; cnt < frame.Count; cnt++)
            {
                CircleButton circlebutton = new CircleButton();
                circlebutton.grid = frame[cnt] as Grid;
                circlebutton.textBlock = circlebutton.grid.Children.OfType<TextBlock>().First();
                circlebutton.textBlock.Dispatcher.Invoke(() => circlebutton.textBlock.Text = randomList[cnt]);
                buttonList.Add(circlebutton);
            }
        }
        private List<string> createList()
        {
            List<string> returnList = new List<string>();
            int i = 1;
            char ch = 'A';

            for(int cnt = 0; cnt < gridNumber;)
            {
                returnList.Add(i++.ToString());
                cnt++;
                returnList.Add(ch++.ToString());
                cnt++;
            }
            return returnList;
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (sender is Grid)
            {
                //.Children.OfType<Ellipse>().First();
                CircleButton circleButton = new CircleButton();
                circleButton.grid = (Grid)sender;
                circleButton.textBlock = ((Grid)sender).Children.OfType<TextBlock>().First();
                var temp = circleButton.grid.Children.OfType<Ellipse>().First();
                if (temp.Fill == onClickColor) return;
                if (circleButton.textBlock.Text == anser[0])
                {
                    temp.Fill = onClickColor;
                    anser.RemoveAt(0);
                    Console.WriteLine(anser.Count);
                    if (anser.Count <=1)
                    {
                        //집중도 끝나고 이동 루틴
                        isTMTComplete = true;  
                    }
                }
                else
                {
                    Task.Run(() =>
                    {
                        System.IO.Stream str = Properties.Resources.buzzer;
                        SoundPlayer snd = new SoundPlayer(str);
                        snd.Play();
                    });
                    temp.Fill = onFailColor;
                }
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if(sender is Grid)
            {
                var temp = ((Grid)sender).Children.OfType<Ellipse>().First();
                if(temp.Fill !=onClickColor) temp.Fill = onEnterColor;
            } 
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Grid)
            {
                var temp = ((Grid)sender).Children.OfType<Ellipse>().First();
                if (temp.Fill != onClickColor) temp.Fill = onIdelColor;
            }
        }
    }
}
