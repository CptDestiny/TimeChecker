using System;

namespace TimeChecker.WPF.Utility
{
    
    //Data carrier of the Timespans and it must inherit the EventArgs. To be used with the EventHandler
    public class TickEventArgs : EventArgs

    {
        public TimeSpan TimeSpan { get; set; }
    }
}
