namespace MoneySimplify.Core.Models.Reports;

public record IncomesByCategory(string UserId, string Category, int Year, decimal Incomes);
