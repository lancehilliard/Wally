namespace Wally.Core {
    public class BudgetApiCategory {
        public BudgetApiCategory(string displayName, string budgetId, string categoryId, decimal extraDollars) {
            DisplayName = displayName;
            BudgetId = budgetId;
            CategoryId = categoryId;
            ExtraDollars = extraDollars;
        }
        public string DisplayName { get; }
        public string BudgetId { get; }
        public string CategoryId { get; }
        public decimal ExtraDollars { get; }
    }
}