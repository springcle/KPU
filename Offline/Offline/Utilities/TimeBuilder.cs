using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offline.Utilities
{
    public partial class TimeBuilder
    {
        private static TimeBuilder Instance;
        public static TimeBuilder getInstance
        {
            get
            {
                if (Instance == null) Instance = new TimeBuilder();
                return Instance;
            }
        }
        private TimeBuilder() { }
    }
    public partial class TimeBuilder // Bulyear Pattern Class
    {

        private string year = string.Empty;
        private string month = string.Empty;
        private string day = string.Empty;
        private string hour = string.Empty;
        private string min = string.Empty;
        private string sec = string.Empty;


        public TimeBuilder setYear()
        {
            this.year = DateTime.Now.Year.ToString();
            return this;
        }

        public TimeBuilder setMonth()
        {
            this.month = DateTime.Now.Month.ToString();
            return this;
        }

        public TimeBuilder setDay()
        {
            this.day = DateTime.Now.Day.ToString();
            return this;
        }

        public TimeBuilder setTime()
        {
            return setHour().setMin().setSec();
        }

        public TimeBuilder setHour()
        {
            this.hour = DateTime.Now.Hour.ToString();
            return this;
        }

        private TimeBuilder setMin()
        {
            this.min = DateTime.Now.Minute.ToString();
            return this;
        }

        private TimeBuilder setSec()
        {
            this.sec = DateTime.Now.Second.ToString();
            return this;
        }

        public string build()
        {
            StringBuilder time = new StringBuilder();
            if (year != string.Empty)
                time.Append(year);
            if (month != string.Empty)
            {
                if (time.ToString() != null)
                {
                    time.Append("_");
                }
                time.Append(month);
            }
            if (day != string.Empty)
            {
                if (time.ToString() != null)
                {
                    time.Append("_");
                }
                time.Append(day);
            }
            if (time.ToString() != null)
                time.Append(" ");
            if (hour != string.Empty)
            {
                time.Append(hour);
                time.Append("h");
            }
            if (min != string.Empty)
            {
                time.Append(min);
                time.Append("m");
            }
            if (sec != string.Empty)
            {
                time.Append(sec);
                time.Append("s");
            }

            return time.ToString();
        }
    }
}
