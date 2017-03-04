using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMER
{
    class CTimer
    {
        private string name;
        private DateTime sought;

        public CTimer(string st, DateTime t)
        {
            name = st;
            sought = t;
        }

        public CTimer(string st, string time)
        {
            name = st;
            int sec = 0, min = 0, h = 0, day = 0;
            DateTime current = DateTime.UtcNow;
            int i = (time.Length - 1);
            sec = t(time, i);
            min = t(time, i);
            if (min == 0) min = current.Minute;
            h = t(time, i);
            if (h == 0) h = current.Hour;
            day = t(time, i);
            if (day == 0) day = current.Day;
            sought = new DateTime(current.Year, current.Month, day, h, min, sec);
        }

        public DateTime get_sought()
        {
            return sought;
        }

        private int t(string st, int i)
        {
            int res = 0;
            int mn = 1;
            while ((i >= 0) && (st[i] != ':'))
            {
                res += ((st[i] - 48) * mn);
                mn *= 10;
                i--;
            }
            i--;
            return res;
        }
    }
}
