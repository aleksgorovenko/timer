using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СTIMER
{
    class CTimer
    {
        private string name;
        private DateTime sought;
        private int i;
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
            i = (time.Length - 1);
            sec = t(time);
            min = t(time);
            if (min == 0) min = current.Minute;
            //if (sec < current.Second) min++;
            h = t(time);
            if (h == 0) h = current.Hour;
            day = t(time);
            if (day == 0) day = current.Day;
            sought = new DateTime(current.Year, current.Month, day, h, min, sec);
        }

        public DateTime get_sought()//Получение времени-
        {
            return sought;
        }

        public string get_name()//получение имени таймера
        {
            return name;
        }
        private int t(string st)//получение значения времени
        {
            int res = 0;
            int mn = 1;
            while ((i >= 0) && (st[i] != ':') && (st[i] != '.'))
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
