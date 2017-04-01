using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offline.DataStructure
{
    public class EEG
    {
        public int ch1 { get; private set; }
        public int ch2 { get; private set; }
        public int ch3 { get; private set; }
        public int ch4 { get; private set; }
        public int ch5 { get; private set; }
        public int ch6 { get; private set; }
        public int ch7 { get; private set; }
        public int ch8 { get; private set; }

        public EEG(int[] ch1_8)
        {
            ch1 = ch1_8[0];
            ch2 = ch1_8[1];
            ch3 = ch1_8[2];
            ch4 = ch1_8[3];
            ch5 = ch1_8[4];
            ch6 = ch1_8[5];
            ch7 = ch1_8[6];
            ch8 = ch1_8[7];
        }

        public EEG()
        {
            ch1 = 0;
            ch2 = 0;
            ch3 = 0;
            ch4 = 0;
            ch5 = 0;
            ch6 = 0;
            ch7 = 0;
            ch8 = 0;
        }
    }
}
