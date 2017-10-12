using Offline.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Offline.Frame.Test
{
    /// <summary>
    /// ResultLoading.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ResultLoading : BaseFrame
    {
        public static List<double> meditationTrend = new List<double>();
        public static List<double> concentrationTrend = new List<double>();
        public static double brainLR = new double();
        public static double sendMeditation;
        public static double sendConcentration;

        //전중후중후
        public static int m_start = 10;
        public static int m_end = 70;
        public static int m_finish = 80;
        public static int c_start = 90;
        public static int c_end;
        public static int c_finish;

        public struct Quantum
        {
            public List<double> before;
            public List<double> ing;
            public List<double> after;
        }


        public struct Concentration
        {
            public List<List<double>> ch_mean;
            public List<List<double>> ch_each_time;
        }

        public struct Meditation
        {
            public List<List<double>> ch_mean;
            public List<List<double>> ch_each_time;
        }

        public ResultLoading() : base("ResultLoading")
        {
            InitializeComponent();
        }
        public override void OnLoaded()
        {
            Processing();
        }
        private async void Processing()
        {
            await Task.Run(() =>
            {
                processing();
            });
            FrameManager.GetInstance.LoadFrame(FrameName.FrameAnalysisResult);
        }
        private void processing()
        {

            try
            {
                IOManager.getInstance.ReadOpen();
                var data = IOManager.getInstance.read();
                foreach (var each in data)
                {
                    DataManager.getInstance.add(each);
                }
                IOManager.getInstance.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            //수정 여기서부터
            int dataCount = DataManager.getInstance.list_ch_data[0].Count;
            int timeCount = dataCount / 256;

            c_end = timeCount - 10;
            c_finish = timeCount;

            Concentration concentration;
            Meditation meditation;
            List<double> brainActivity = new List<double>();

            concentration.ch_mean = new List<List<double>>();
            concentration.ch_each_time = new List<List<double>>();

            meditation.ch_mean = new List<List<double>>();
            meditation.ch_each_time = new List<List<double>>();


            for (int i = 0; i < 8; i++)
            {
                concentration.ch_mean.Add(new List<double>()); //3
                concentration.ch_each_time.Add(new List<double>()); //(timeCount)

                meditation.ch_mean.Add(new List<double>());
                meditation.ch_each_time.Add(new List<double>());
            }
            //signalPower.GetRange(0, 9);
            for (int i = 0; i < timeCount; i++)
            {
                concentrationTrend.Add(0);
                meditationTrend.Add(0);
                double[] LRBrainTotalPower = new double[2];
                for (int j = 0; j < 8; j++)
                {
                    int minI = i * 256;
                    List<double> current = DataManager.getInstance.list_ch_data[j].GetRange(minI, 256);
                    List<double> fftResult = FFTManager.getInstance.fft(current);
                    
                    indicatorManager.getInstance.setData(fftResult);
                    if (j % 2 == 0)
                        LRBrainTotalPower[0] += indicatorManager.getInstance.totalPower();
                    else
                        LRBrainTotalPower[1] += indicatorManager.getInstance.totalPower();
                    concentration.ch_each_time[j].Add(indicatorManager.getInstance.concentration());
                    meditation.ch_each_time[j].Add(indicatorManager.getInstance.meditation());
                }
                brainActivity.Add(LRBrainTotalPower[0] / (LRBrainTotalPower[0] + LRBrainTotalPower[1]));
            }

            for (int i = 0; i < 8; i++)
            {
                Quantum qConcentration;
                Quantum qMeditation;
                
                qConcentration.before = concentration.ch_each_time[i].GetRange(m_finish, 10);
                qConcentration.ing = concentration.ch_each_time[i].GetRange(c_start, c_end - c_start);
                qConcentration.after = concentration.ch_each_time[i].GetRange(c_end, 10);

                qMeditation.before = meditation.ch_each_time[i].GetRange(0, 10);
                qMeditation.ing = meditation.ch_each_time[i].GetRange(m_start, 60);
                qMeditation.after = meditation.ch_each_time[i].GetRange(m_end, 10);

                concentration.ch_mean[i].Add(qConcentration.before.Average());
                concentration.ch_mean[i].Add(qConcentration.ing.Average());
                concentration.ch_mean[i].Add(qConcentration.after.Average());
                
                meditation.ch_mean[i].Add(qMeditation.before.Average());
                meditation.ch_mean[i].Add(qMeditation.ing.Average());
                meditation.ch_mean[i].Add(qMeditation.after.Average());

            }
            double[] concentration_total = new double[3];
            double[] meditation_total = new double[3];         

            for (int i = 0; i < 8; i++)
            {
                concentration_total[0] += concentration.ch_mean[i][0];
                concentration_total[1] += concentration.ch_mean[i][1];
                concentration_total[2] += concentration.ch_mean[i][2];

                meditation_total[0] += meditation.ch_mean[i][0];
                meditation_total[1] += meditation.ch_mean[i][1];
                meditation_total[2] += meditation.ch_mean[i][2];
            }

            //전중후 집중도(위), 명상도(아래) 평균값 
           
            concentration_total[0] /= 8;
            concentration_total[1] /= 8;
            concentration_total[2] /= 8;

            meditation_total[0] /= 8;
            meditation_total[1] /= 8;
            meditation_total[2] /= 8;

            Console.WriteLine("집중도 전 " + concentration_total[0]);
            Console.WriteLine("집중도 중 " + concentration_total[1]);
            Console.WriteLine("집중도 후 " + concentration_total[2]);

            Console.WriteLine("");

            Console.WriteLine("명상도 전 " + meditation_total[0]);
            Console.WriteLine("명상도 중 " + meditation_total[1]);
            Console.WriteLine("명상도 후 " + meditation_total[2]);

            Console.WriteLine("");

            Console.WriteLine("좌우뇌 활성도 " + brainActivity.Average());

            //채널 당 초만큼 집중도 [채널][sec]
            for(int i=0; i<timeCount; i++)
            {
                for(int j=0; j<8; j++)
                {
                    concentrationTrend[i] += concentration.ch_each_time[j][i];
                    meditationTrend[i] += meditation.ch_each_time[j][i];
                }
                concentrationTrend[i] /= 8;
                meditationTrend[i] /= 8;
            }

            brainLR = brainActivity.Average();
            sendMeditation = meditation_total[1] + meditation_total[2] / 2;
            sendConcentration = concentration_total[1] + concentration_total[2] / 2;
            Console.WriteLine(brainLR);
        }
    }
}
