using MathNet.Numerics.IntegralTransforms;
using System;
using System.Collections.Generic;
using System.Numerics;


namespace Offline.Manager
{
    //SingleTone Proputy
    public partial class FFTManager
    {


        private static FFTManager Instance;
        public static FFTManager getInstance
        {
            get
            {
                if (Instance == null) Instance = new FFTManager();
                return Instance;
            }
        }
        private FFTManager() { }
    }

    public partial class FFTManager
    {
        public List<double> fft(List<double> rawData)
        {
           
            Complex[] signalFFT = new Complex[rawData.Count];
            for (int i = 0; i < rawData.Count; i++)
            {
                signalFFT[i] = rawData[i]; //(rawData[i], 0)
            }

            Fourier.Forward(signalFFT);

            // 그래프 그릴때 x축값 배열, 주파수 대역 count,rate
            double[] fftFreq = Fourier.FrequencyScale(rawData.Count, 250);

            List<double> signalPower = new List<double>();
            for (int i = 0; i < rawData.Count; i++)
            {
                double imaginary = Math.Abs(Math.Pow(signalFFT[i].Imaginary, 2));
                double Real = Math.Abs(Math.Pow(signalFFT[i].Real, 2));
                signalPower.Add(10 * Math.Log10(imaginary + Real));
            }
            return signalPower;
        }
    }

    public partial class indicatorManager
    {
        public struct Frequency
        {
            public List<double> delta;
            public List<double> theta;
            public List<double> alpha;
            public List<double> SMR;
            public List<double> midBeta;
            public List<double> highBeta;
            public List<double> slowBeta;
            public List<double> total;
        };

        //0~60hz
        public struct FrequencyPower
        {
            public double delta;
            public double theta;
            public double alpha;
            public double SMR;
            public double midBeta;
            public double highBeta;

            public double slowBeta;
            public double beta;
            public double total;
        }

        private static indicatorManager Instance;
        public static indicatorManager getInstance
        {
            get
            {
                if (Instance == null) Instance = new indicatorManager();
                return Instance;
            }
        }

        public Frequency frequency;
        public FrequencyPower frequencyPower;

        private indicatorManager()
        {
            frequency = new Frequency();
            frequencyPower = new FrequencyPower();

            frequency.delta = new List<double>();
            frequency.theta = new List<double>();
            frequency.alpha = new List<double>();
            frequency.SMR = new List<double>();
            frequency.midBeta = new List<double>();
            frequency.highBeta = new List<double>();

            frequency.slowBeta = new List<double>();
            frequency.total = new List<double>();
        }
    }

    public partial class indicatorManager
    {
        public void setData(List<double> signalPower)
        {
            frequencyPower.delta = 0;
            frequencyPower.theta = 0;
            frequencyPower.alpha = 0;
            frequencyPower.SMR = 0;
            frequencyPower.midBeta = 0;
            frequencyPower.highBeta = 0;

            frequencyPower.beta = 0;
            frequencyPower.slowBeta = 0;
            frequencyPower.total = 0;

            frequency.delta = signalPower.GetRange(0, 9);
            frequency.theta = signalPower.GetRange(8, 9);
            frequency.alpha = signalPower.GetRange(16, 11);
            frequency.SMR = signalPower.GetRange(26, 7);
            frequency.midBeta = signalPower.GetRange(30, 7);
            frequency.highBeta = signalPower.GetRange(36, 25);

            frequency.slowBeta = signalPower.GetRange(26, 15);
            frequency.total = signalPower.GetRange(0, 61);

            for (int i = 0; i < frequency.delta.Count; i++)
                frequencyPower.delta += frequency.delta[i];
            for (int i = 0; i < frequency.theta.Count; i++)
                frequencyPower.theta += frequency.theta[i];
            for (int i = 0; i < frequency.alpha.Count; i++)
                frequencyPower.alpha += frequency.alpha[i];
            for (int i = 0; i < frequency.SMR.Count; i++)
                frequencyPower.SMR += frequency.SMR[i];
            for (int i = 0; i < frequency.midBeta.Count; i++)
                frequencyPower.midBeta += frequency.midBeta[i];
            for (int i = 0; i < frequency.highBeta.Count; i++)
                frequencyPower.highBeta += frequency.highBeta[i];
            for (int i = 0; i < frequency.slowBeta.Count; i++)
                frequencyPower.slowBeta += frequency.slowBeta[i];
            for (int i = 0; i < frequency.total.Count; i++)
                frequencyPower.total += frequency.total[i];

            frequencyPower.beta = (frequencyPower.SMR + frequencyPower.midBeta) / 14;

            frequencyPower.delta /= 9;
            frequencyPower.theta /= 9;
            frequencyPower.alpha /= 11;
            frequencyPower.SMR /= 7;
            frequencyPower.midBeta /= 7;
            frequencyPower.highBeta /= 25;

            frequencyPower.slowBeta /= 15;
            frequencyPower.total /= 61;
        }

        public double concentration()
        {
            return frequencyPower.beta / (frequencyPower.theta + frequencyPower.beta);
        }

        public double meditation()
        {
            return frequencyPower.alpha / (frequencyPower.alpha + frequencyPower.highBeta);
        }

        public double activity()
        {
            return frequencyPower.slowBeta / (frequencyPower.alpha + frequencyPower.slowBeta);
        }

        //좌우뇌활성도 = left ch(1, 3, 5, 7), right ch(2, 4, 6, 8)
        public double totalPower()
        {
            return frequencyPower.total;
        }
    }
}
