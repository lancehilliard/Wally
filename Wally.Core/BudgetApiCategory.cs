namespace Wally.Core {
    public class BudgetApiCategory {
        public BudgetApiCategory(string displayName, string budgetId, string categoryId) {
            DisplayName = displayName;
            BudgetId = budgetId;
            CategoryId = categoryId;
        }
        public string DisplayName { get; private set; }
        public string BudgetId { get; private set; }
        public string CategoryId { get; private set; }
    }
}