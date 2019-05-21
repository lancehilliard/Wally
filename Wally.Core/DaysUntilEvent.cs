using System;
using System.Collections.Generic;
using System.Text;

namespace Wally.Core
{
    public class DaysUntilEvent
    {
        public DaysUntilEvent(string name, DateTime when, int displayCountInDays)
        {
            Name = name;
            When = when;
            DisplayCountInDays = displayCountInDays;
        }
        public DateTime When { get; }
        public int DisplayCountInDays { get; }
        public string Name { get; }
        public int DaysUntil
        {
            get
            {
                var timespanUntil = When.Date - DateTime.Now.Date;
                var result = (int)Math.Floor(timespanUntil.TotalDays);
                return result;
            }
        }
    }
}
