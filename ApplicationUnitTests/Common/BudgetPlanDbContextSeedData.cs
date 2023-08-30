using BudgetPlan.Domain.Entities;
using BudgetPlan.Persistence;
using BudgetPlan.Shared.Enums;

namespace ApplicationUnitTests.Common;

public static class BudgetPlanDbContextSeedData
{
    public static void Seed(BudgetPlanDbContext context)
    {
        context.TransactionCategories.AddRange(new[]
        {
            new TransactionCategory
            {
                Id = 1,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 1, 1),
                StatusId = 1,
                TransactionCategoryName = "Zarobki",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 2,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 1, 1),
                StatusId = 1,
                TransactionCategoryName = "Praca",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = 1
            },
            new TransactionCategory
            {
                Id = 3,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 1, 1),
                StatusId = 1,
                TransactionCategoryName = "Premie",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = 1
            },
            new TransactionCategory
            {
                Id = 4,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 1, 1),
                StatusId = 1,
                TransactionCategoryName = "Jedzenie",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 5,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 1, 1),
                StatusId = 1,
                TransactionCategoryName = "Jedzenie dom",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 4
            },
            new TransactionCategory
            {
                Id = 6,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 1, 1),
                StatusId = 1,
                TransactionCategoryName = "Jedzenie miasto",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 4
            },
            new TransactionCategory
            {
                Id = 7,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 1, 1),
                StatusId = 1,
                TransactionCategoryName = "Mieszkanie",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 8,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 1, 1),
                StatusId = 1,
                TransactionCategoryName = "Czynsz",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 7
            },
        });

        context.SaveChanges();
    }
}