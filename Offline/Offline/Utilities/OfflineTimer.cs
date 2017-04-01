using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offline.Utilities
{
    class OfflineTimer
    {
        public bool isTimeCheck { get; private set; }
        public DateTime startTime
        {
            get; private set;
        }
        public TimeSpan currentTime
        {
            get
            {
                return DateTime.Now - startTime;
            }
        }
        public void start()
        {
            if (isTimeCheck) return;
            startTime = DateTime.Now;
            isTimeCheck = true;
        }
        public void stop()
        {
            if (!isTimeCheck) return;
            startTime = DateTime.MinValue;
            isTimeCheck = false;
        }
    }
}
