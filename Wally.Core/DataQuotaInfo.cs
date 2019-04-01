namespace Wally.Core {
    public class DataQuotaInfo {
        public DataQuotaInfo(decimal allowableUsage, decimal totalUsage, string unitOfMeasure, string monthName) {
            AllowableUsage = allowableUsage;
            TotalUsage = totalUsage;
            UnitOfMeasure = unitOfMeasure;
            MonthName = monthName;
        }
        public decimal AllowableUsage { get; set; }
        public decimal TotalUsage { get; set; }
        public string UnitOfMeasure { get; }
        public string MonthName { get; }
    }
}