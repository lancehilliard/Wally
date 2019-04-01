namespace Wally.Core {
    public class QuotaMonth {
        public QuotaMonth(string monthName, string usage) {
            MonthName = monthName;
            Usage = usage;
        }

        public string MonthName { get; }
        public string Usage { get; }
    }
}