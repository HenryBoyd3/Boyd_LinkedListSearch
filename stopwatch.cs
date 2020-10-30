using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Boyd_LinkedListSearch
{
    class stopwatch
    {
        Stopwatch timer = new Stopwatch();
        public int nodesMovedThrough { get; set; }
        public void startTimer() //I think I could have made this a property if I wanted to get rid of () but I forget
        {
            timer.Start();
        }
        public void stopTimer()
        {
            timer.Stop();
        }
        public string outputTime()
        {
            TimeSpan total = timer.Elapsed;
            string formatedTime = string.Format(" Minutes {0:00} Seconds {1:00} Milliseconds {2} \nTotal nodes" +
                " moved through is to try to find this name was {3}", 
                total.Minutes, total.Seconds, total.TotalMilliseconds, nodesMovedThrough );
            timer.Reset();

            return formatedTime; 
        }
        



    }
}
