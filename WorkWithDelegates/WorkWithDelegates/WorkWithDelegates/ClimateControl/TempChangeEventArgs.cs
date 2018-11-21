using System;

namespace WorkWithDelegates.ClimateControl
{
    public class TempChangeEventArgs : EventArgs
    {
        public int Temperature { get; set; }
        public TempChangeEventArgs(int temp)
        {
            Temperature = temp;
        }
    }
}
