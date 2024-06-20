using BudgetPlan.Shared.ViewModels;
using JetBrains.Annotations;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Tests.UnitTests.ViewModels
{
    [TestSubject(typeof(BudgetPlanCategoriesDataDto))]
    public class BudgetPlanCategoriesDataDtoTest
    {
        [Fact]
        public void InitializeViewModel_ValueIsNotNull()
        {
            // Arrange
            var transactionCategories = new List<TransactionCategory>();
            transactionCategories.Add(TransactionCategory.CreateOverTransactionCategory("category1", TransactionType.Expense,
                new Guid("3f1301b5-d219-4f3a-97ce-8b7af1eca64c")));
            transactionCategories.Add(TransactionCategory.CreateOverTransactionCategory("category2", TransactionType.Income,
                new Guid("f29f240d-7961-4bc7-b45b-faa8fe7019a3")));

            // Act
            var viewModel = new BudgetPlanCategoriesDataDto(transactionCategories);

            // Assert
            viewModel.ShouldNotBeNull();
        }

        [Fact]
        public void InitializeViewModel_OverTransactionCategoryListPropertyIsNotEmpty()
        {
            // Arrange
            var transactionCategories = new List<TransactionCategory>();
            transactionCategories.Add(TransactionCategory.CreateOverTransactionCategory("category1", TransactionType.Expense,
                new Guid("3f1301b5-d219-4f3a-97ce-8b7af1eca64c")));
            transactionCategories.Add(TransactionCategory.CreateOverTransactionCategory("category2", TransactionType.Income,
                new Guid("f29f240d-7961-4bc7-b45b-faa8fe7019a3")));

            // Act
            var viewModel = new BudgetPlanCategoriesDataDto(transactionCategories);

            // Assert
            viewModel.OverTransactionCategoryList.ShouldNotBeEmpty();
        }

        [Fact]
        public void InitializeViewModel_EmptyList_OverTransactionCategoryListPropertyIsEmpty()
        {
            // Arrange
            var transactionCategories = new List<TransactionCategory>();

            // Act
            var viewModel = new BudgetPlanCategoriesDataDto(transactionCategories);

            // Assert
            viewModel.OverTransactionCategoryList.ShouldBeEmpty();
        }
    }
}