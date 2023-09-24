using BudgetPlan.Domain.Entities;
using BudgetPlan.Persistence;
using BudgetPlan.Shared.Enums;

namespace ApplicationUnitTests.Common;

public static class BudgetPlanDbContextSeedData
{
    private const string CREATED_BY = "user@user.pl";
    
    public static void Seed(BudgetPlanDbContext context)
    {
        context.TransactionCategories.AddRange(new[]
        {
            new TransactionCategory
            {
                Id = 1,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Earnings",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 2,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Work",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = 1
            },
            new TransactionCategory
            {
                Id = 3,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Home",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 4,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Food",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 3
            },
            new TransactionCategory
            {
                Id = 5,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Rent",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 3
            },
            new TransactionCategory
            {
                Id = 6,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Others",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 7,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Car fuel",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 6
            },
            new TransactionCategory
            {
                Id = 8,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Education",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 6
            }
        });

        context.BudgetPlanBases.AddRange(new[]
        {
            new BudgetPlanBase
            {
                Id = 1,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                BudgetPlanDetailsList = null,
            }
        });
        
        context.BudgetPlanDetails.AddRange(new []
        {
            new BudgetPlanDetails
            {
                Id = 1,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 5500,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = 1,
                TransactionCategoryId = 2,
            },
            new BudgetPlanDetails
            {
                Id = 2,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 1500,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = 1,
                TransactionCategoryId = 4,
            },
            new BudgetPlanDetails
            {
                Id = 3,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 2000,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = 1,
                TransactionCategoryId = 5,
            },
            new BudgetPlanDetails
            {
                Id = 4,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 500,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = 1,
                TransactionCategoryId = 7,
            },
            new BudgetPlanDetails
            {
                Id = 5,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 1000,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = 1,
                TransactionCategoryId = 8,
            },
        });
        
        context.TransactionDetails.AddRange(new []
        {
            new TransactionDetail
            {
                Id = 1,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,10),
                StatusId = 1,
                Value = 5500,
                Description = "Salary",
                TransactionDate = new DateTime(2023,9,10),
                TransactionCategoryId = 2,
            },
            new TransactionDetail
            {
                Id = 2,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,10),
                StatusId = 1,
                Value = 2000,
                Description = "Rent",
                TransactionDate = new DateTime(2023,9,10),
                TransactionCategoryId = 5,
            },
            new TransactionDetail
            {
                Id = 3,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,10),
                StatusId = 1,
                Value = 1000,
                Description = "Education",
                TransactionDate = new DateTime(2023,9,10),
                TransactionCategoryId = 8
            },
            new TransactionDetail
            {
                Id = 4,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,11),
                StatusId = 1,
                Value = 140,
                Description = "Car fuel",
                TransactionDate = new DateTime(2023,9,11),
                TransactionCategoryId = 7,
            },
            new TransactionDetail
            {
                Id = 5,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,11),
                StatusId = 1,
                Value = 150,
                Description = "Food shop",
                TransactionDate = new DateTime(2023,9,11),
                TransactionCategoryId = 4,
            },
            new TransactionDetail
            {
                Id = 6,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,18),
                StatusId = 1,
                Value = 250,
                Description = "Food shop",
                TransactionDate = new DateTime(2023,9,18),
                TransactionCategoryId = 4,
            }
        });


        context.SaveChanges();
    }
}