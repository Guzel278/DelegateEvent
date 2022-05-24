using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateEvent
{

    internal class Alarm
    {
        public delegate void AlarmHandler(Alarm sender, AlarmEventArgs e);
        public event AlarmHandler OnExecute;
        public event AlarmHandler OnSetTime;
        
        System.Threading.Timer timer;
        public void SetTime(TimeSpan time, Action a)
        {          
           Tuple<Action, TimeSpan> tuple = new Tuple<Action, TimeSpan>(a, time);
           timer = new System.Threading.Timer(OnTimerExecuted, tuple, time, Timeout.InfiniteTimeSpan);
           OnSetTime?.Invoke(this, new AlarmEventArgs(time));               
        }
        public void OnTimerExecuted(Object stateInfo)
        {
            Tuple<Action, TimeSpan> tuple = (Tuple<Action, TimeSpan>)stateInfo;
            tuple.Item1();          
            OnExecute?.Invoke(this, new AlarmEventArgs(tuple.Item2));            
        }
    }

}
