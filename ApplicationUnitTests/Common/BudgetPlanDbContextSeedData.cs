using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Persistence;

namespace ApplicationUnitTests.Common;

public static class BudgetPlanDbContextSeedData
{
    public const string CREATED_BY = "user@user.pl";
    public static Guid TRANSACTION_CATEGORY_1_GUID = new Guid("d7b2bba5-2c34-48ea-adfb-1135e76c7664"); // Earnings
    public static Guid TRANSACTION_CATEGORY_2_GUID = new Guid("82f63e23-b538-496e-9e52-176b489b794f"); // Salary
    public static Guid TRANSACTION_CATEGORY_3_GUID = new Guid("c9f120f7-783f-40ea-9b2d-e0e0e54d24ab"); // Home
    public static Guid TRANSACTION_CATEGORY_4_GUID = new Guid("a2d9d0c2-57b6-40a3-bfd3-679983c22d8a"); // Food
    public static Guid TRANSACTION_CATEGORY_5_GUID = new Guid("e0e080c7-4bb1-4f6e-bf4a-7f8bfb891f82"); // Rent
    public static Guid TRANSACTION_CATEGORY_6_GUID = new Guid("1fe50bca-2015-45d5-87c2-7cd195a74aa7"); // Others
    public static Guid TRANSACTION_CATEGORY_7_GUID = new Guid("dd4f852c-112c-4d9f-8e2f-76fdd0a1e3c1"); // Car fuel
    public static Guid TRANSACTION_CATEGORY_8_GUID = new Guid("8f4e62c8-3e0f-43ca-9d9f-cdecad5ff9b2"); // Education
    public static Guid BUDGET_PLAN_BASE_1_GUID = new Guid("ba6b61b8-cb33-4d91-8f75-0f9da1d74151");
    public static Guid BUDGET_PLAN_DETAILS_1_GUID = new Guid("0e157ffb-35df-4e90-98d1-d343ff944ed5");
    public static Guid BUDGET_PLAN_DETAILS_2_GUID = new Guid("f9a95b6c-9c3c-47d4-84d2-17e5c2ff35c2");
    public static Guid BUDGET_PLAN_DETAILS_3_GUID = new Guid("d5c6e5b3-6c36-4a86-aaae-e3fbbf785cdc");
    public static Guid BUDGET_PLAN_DETAILS_4_GUID = new Guid("36a45cb2-d86f-4e99-9969-d263ce4f5b80");
    public static Guid BUDGET_PLAN_DETAILS_5_GUID = new Guid("9f81f6c9-920b-4c36-b3c6-2c93aa0e318a");
    public static Guid TRANSACTION_DETAILS_1_GUID = new Guid("f8bb5af6-1ea4-4cfd-86ab-097fa2e4bc77");
    public static Guid TRANSACTION_DETAILS_2_GUID = new Guid("4d5aafce-eed2-4e5b-bf07-8d6f2f481b11");
    public static Guid TRANSACTION_DETAILS_3_GUID = new Guid("f65b47f3-5e6b-4b7e-997e-45313cfbbef9");
    public static Guid TRANSACTION_DETAILS_4_GUID = new Guid("7b4582dd-c79f-4bf4-8b4b-56efb9f7b984");
    public static Guid TRANSACTION_DETAILS_5_GUID = new Guid("aebc78d5-0c61-462d-a1f4-2d09aa2b1e9c");
    public static Guid TRANSACTION_DETAILS_6_GUID = new Guid("d55d7d2a-eaea-4f29-9f11-01b55d2be5db");

    
    public static void Seed(BudgetPlanDbContext context)
    {
        context.TransactionCategories.AddRange(new[]
        {
            new TransactionCategory
            {
                Id = TRANSACTION_CATEGORY_1_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Earnings",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = TRANSACTION_CATEGORY_2_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Work",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = TRANSACTION_CATEGORY_1_GUID
            },
            new TransactionCategory
            {
                Id = TRANSACTION_CATEGORY_3_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Home",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = TRANSACTION_CATEGORY_4_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Food",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = TRANSACTION_CATEGORY_3_GUID
            },
            new TransactionCategory
            {
                Id = TRANSACTION_CATEGORY_5_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Rent",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = TRANSACTION_CATEGORY_3_GUID
            },
            new TransactionCategory
            {
                Id = TRANSACTION_CATEGORY_6_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Others",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = TRANSACTION_CATEGORY_7_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Car fuel",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = TRANSACTION_CATEGORY_6_GUID
            },
            new TransactionCategory
            {
                Id = TRANSACTION_CATEGORY_8_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
                TransactionCategoryName = "Education",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = TRANSACTION_CATEGORY_6_GUID
            }
        });

        context.BudgetPlanBases.AddRange(new[]
        {
            new BudgetPlanBase
            {
                Id = BUDGET_PLAN_BASE_1_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023, 9, 1),
                StatusId = 1,
            }
        });
        
        context.BudgetPlanDetails.AddRange(new []
        {
            new BudgetPlanDetails
            {
                Id = BUDGET_PLAN_DETAILS_1_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 5500,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = BUDGET_PLAN_BASE_1_GUID,
                TransactionCategoryId = TRANSACTION_CATEGORY_2_GUID,
            },
            new BudgetPlanDetails
            {
                Id = BUDGET_PLAN_DETAILS_2_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 1500,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = BUDGET_PLAN_BASE_1_GUID,
                TransactionCategoryId = TRANSACTION_CATEGORY_4_GUID,
            },
            new BudgetPlanDetails
            {
                Id = BUDGET_PLAN_DETAILS_3_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 2000,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = BUDGET_PLAN_BASE_1_GUID,
                TransactionCategoryId = TRANSACTION_CATEGORY_5_GUID,
            },
            new BudgetPlanDetails
            {
                Id = BUDGET_PLAN_DETAILS_4_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 500,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = BUDGET_PLAN_BASE_1_GUID,
                TransactionCategoryId = TRANSACTION_CATEGORY_7_GUID,
            },
            new BudgetPlanDetails
            {
                Id = BUDGET_PLAN_DETAILS_5_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,1),
                StatusId = 1,
                ExpectedAmount = 1000,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = BUDGET_PLAN_BASE_1_GUID,
                TransactionCategoryId = TRANSACTION_CATEGORY_8_GUID,
            },
        });
        
        context.TransactionDetails.AddRange(new []
        {
            new TransactionDetail
            {
                Id = TRANSACTION_DETAILS_1_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,10),
                StatusId = 1,
                Value = 5500,
                Description = "Salary",
                TransactionDate = new DateTime(2023,9,10),
                TransactionCategoryId = TRANSACTION_CATEGORY_2_GUID,
            },
            new TransactionDetail
            {
                Id = TRANSACTION_DETAILS_2_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,10),
                StatusId = 1,
                Value = 2000,
                Description = "Rent",
                TransactionDate = new DateTime(2023,9,10),
                TransactionCategoryId = TRANSACTION_CATEGORY_5_GUID,
            },
            new TransactionDetail
            {
                Id = TRANSACTION_DETAILS_3_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,10),
                StatusId = 1,
                Value = 1000,
                Description = "Education",
                TransactionDate = new DateTime(2023,9,10),
                TransactionCategoryId = TRANSACTION_CATEGORY_8_GUID,
            },
            new TransactionDetail
            {
                Id = TRANSACTION_DETAILS_4_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,11),
                StatusId = 1,
                Value = 140,
                Description = "Car fuel",
                TransactionDate = new DateTime(2023,9,11),
                TransactionCategoryId = TRANSACTION_CATEGORY_7_GUID,
            },
            new TransactionDetail
            {
                Id = TRANSACTION_DETAILS_5_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,11),
                StatusId = 1,
                Value = 150,
                Description = "Food shop",
                TransactionDate = new DateTime(2023,9,11),
                TransactionCategoryId = TRANSACTION_CATEGORY_4_GUID,
            },
            new TransactionDetail
            {
                Id = TRANSACTION_DETAILS_6_GUID,
                CreatedBy = CREATED_BY,
                Created = new DateTime(2023,9,18),
                StatusId = 1,
                Value = 250,
                Description = "Food shop",
                TransactionDate = new DateTime(2023,9,18),
                TransactionCategoryId = TRANSACTION_CATEGORY_4_GUID,
            }
        });


        context.SaveChanges();
    }
}