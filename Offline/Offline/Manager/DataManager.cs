using Offline.DataStructure;
using System.Collections.Generic;

namespace Offline.Manager
{
    public partial class DataManager
    {
        public struct EEG_each_ch
        {
            public List<int> ch1;
            public List<int> ch2;
            public List<int> ch3;
            public List<int> ch4;
            public List<int> ch5;
            public List<int> ch6;
            public List<int> ch7;
            public List<int> ch8;
        };

        private static DataManager Instance;
        public static DataManager getInstance
        {
            get
            {
                if (Instance == null) Instance = new DataManager();
                return Instance;
            }
        }

        public List<EEG> EEG_data;
        public EEG_each_ch each_ch_data;
        public List<EEG> analysis_EEG_data;

        private DataManager()
        {
            EEG_data = new List<EEG>();
            each_ch_data = new EEG_each_ch();
            analysis_EEG_data = new List<EEG>();

            each_ch_data.ch1 = new List<int>();
            each_ch_data.ch2 = new List<int>();
            each_ch_data.ch3 = new List<int>();
            each_ch_data.ch4 = new List<int>();
            each_ch_data.ch5 = new List<int>();
            each_ch_data.ch6 = new List<int>();
            each_ch_data.ch7 = new List<int>();
            each_ch_data.ch8 = new List<int>();
        }
    }

    public partial class DataManager
    {
        public void add(EEG eeg)
        {
            EEG_data.Add(eeg);

            each_ch_data.ch1.Add(eeg.ch1);
            each_ch_data.ch2.Add(eeg.ch2);
            each_ch_data.ch3.Add(eeg.ch3);
            each_ch_data.ch4.Add(eeg.ch4);
            each_ch_data.ch5.Add(eeg.ch5);
            each_ch_data.ch6.Add(eeg.ch6);
            each_ch_data.ch7.Add(eeg.ch7);
            each_ch_data.ch8.Add(eeg.ch8);
        }
    }
}
