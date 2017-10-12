using Offline.DataStructure;
using System.Collections.Generic;

namespace Offline.Manager
{
    public partial class DataManager
    {
        private static DataManager Instance;
        public static DataManager getInstance
        {
            get
            {
                if (Instance == null) Instance = new DataManager();
                return Instance;
            }
        }
        public List<List<double>> list_ch_data;

        private DataManager()
        {
            list_ch_data = new List<List<double>>();
            for(int cnt = 0; cnt < 8; cnt++)
            {
                list_ch_data.Add(new List<double>());
            }
            
        }
    }

    public partial class DataManager
    { 

        public void add(EEG eeg)
        {
            list_ch_data[0].Add(eeg.ch1);
            list_ch_data[1].Add(eeg.ch2);
            list_ch_data[2].Add(eeg.ch3);
            list_ch_data[3].Add(eeg.ch4);
            list_ch_data[4].Add(eeg.ch5);
            list_ch_data[5].Add(eeg.ch6);
            list_ch_data[6].Add(eeg.ch7);
            list_ch_data[7].Add(eeg.ch8);
        }

        public void clear()
        {
            list_ch_data = new List<List<double>>();
            list_ch_data[0] = new List<double>();
            list_ch_data[1] = new List<double>();
            list_ch_data[2] = new List<double>();
            list_ch_data[3] = new List<double>();
            list_ch_data[4] = new List<double>();
            list_ch_data[5] = new List<double>();
            list_ch_data[6] = new List<double>();
            list_ch_data[7] = new List<double>();
        }
    }
}
