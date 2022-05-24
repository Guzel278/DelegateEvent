using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent
{
    internal class AlarmEventArgs
    {
        public AlarmEventArgs(TimeSpan time)
        {
            Time = time;
        }
        public TimeSpan Time { get; private set; }
    }
}
