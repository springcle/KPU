using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Offline.DataStructure;

namespace Offline.Manager
{
    public  class EegPattern
    {
        EEG meanEEG = new EEG();
        public bool blink_detect(EEG eeg)
        {
            if (((Math.Abs(eeg.ch1) - meanEEG.ch1) > 100) & ((Math.Abs(eeg.ch1) > 100)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
