using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Managers;

public class TransactionCategoryManager(
	ITransactionCategoriesRepository transactionCategoriesRepository,
	IBudgetPlanRepository budgetPlanRepository)
	: ITransactionCategoryManager
{
	public async Task<Guid> AddOverTransactionCategoryAsync(Guid budgetPlanId, string name,
		TransactionType transactionType,
		CancellationToken cancellationToken = default)
	{
		var budgetPlan = await budgetPlanRepository.GetByIdAsync(budgetPlanId, cancellationToken);
		
		var transactionCategory = budgetPlan.AddOverTransactionCategory(name, transactionType);
		
		await budgetPlanRepository.UpdateAsync(budgetPlan, cancellationToken);

		return transactionCategory.Id;
	}

	public async Task<Guid> AddTransactionCategoryAsync(Guid overTransactionCategoryId, string categoryName,
		CancellationToken cancellationToken = default)
	{
		ValidateInputs(overTransactionCategoryId, categoryName);
		var mainTransactionCategory =
			await GetMainTransactionCategoryAsync(overTransactionCategoryId, cancellationToken);

		var transactionCategory =
			await AddSubTransactionCategoryAsync(mainTransactionCategory, categoryName, cancellationToken);

		await UpdateBudgetPlanAsync(mainTransactionCategory.BudgetPlanId, transactionCategory, cancellationToken);

		return transactionCategory.Id;
	}

	public async Task<SubTransactionCategoriesViewModel> GetSubTransactionCategoriesForBudgetPlan(
		Guid requestBudgetPlanId, CancellationToken cancellationToken = default)
	{
		var transactionCategories =
			await transactionCategoriesRepository.GetSubTransactionCategoriesForBudgetPlanAsync(requestBudgetPlanId,
				cancellationToken);

		var subTransactionCategories = transactionCategories
			.Select(transactionCategory => new TransactionCategoryDto(transactionCategory))
			.ToList();

		return new SubTransactionCategoriesViewModel(subTransactionCategories);
	}

	public async Task<TransactionCategoriesForBudgetPlanViewModel> GetTransactionCategoriesForBudgetPlan(
		Guid requestBudgetPlanId, CancellationToken cancellationToken = default)
	{
		var data = await transactionCategoriesRepository
			.GetOverTransactionCategoriesWithSubTransactionCategoriesForBudgetPlanAsync(requestBudgetPlanId,
				cancellationToken);

		TransactionCategoriesForBudgetPlanViewModel viewModel = new(data);

		return viewModel;
	}

	private void ValidateInputs(Guid overTransactionCategoryId, string categoryName)
	{
		if (overTransactionCategoryId.IsNullOrEmpty())
			throw new ArgumentException("Over transaction category id is null or empty.",
				nameof(overTransactionCategoryId));
		if (string.IsNullOrEmpty(categoryName))
			throw new ArgumentException("Category name cannot be null or empty.", nameof(categoryName));
	}

	private async Task<TransactionCategory> GetMainTransactionCategoryAsync(Guid id,
		CancellationToken cancellationToken)
	{
		var otc = await transactionCategoriesRepository.GetOverTransactionCategoryAsync(id, cancellationToken);
		if (otc == null)
			throw new NotFoundException(nameof(otc), id);

		return otc;
	}

	private async Task<TransactionCategory> AddSubTransactionCategoryAsync(TransactionCategory overTransactionCategory,
		string categoryName, CancellationToken cancellationToken)
	{
		var transactionCategory = overTransactionCategory.AddSubTransactionCategory(categoryName);
		await transactionCategoriesRepository.UpdateAsync(overTransactionCategory, cancellationToken);
		return transactionCategory;
	}

	private async Task UpdateBudgetPlanAsync(Guid budgetPlanId, TransactionCategory transactionCategory,
		CancellationToken cancellationToken)
	{
		if (budgetPlanId.IsNullOrEmpty())
			throw new ArgumentException("Budget plan id is null or empty.", nameof(budgetPlanId));

		var budgetPlan = await budgetPlanRepository.GetByIdAsync(budgetPlanId, cancellationToken);
		foreach (var budgetPlanBase in budgetPlan.BudgetPlanBases)
		{
			budgetPlanBase.AddBudgetPlanDetail(transactionCategory.Id);
		}

		await budgetPlanRepository.UpdateAsync(budgetPlan, cancellationToken);
	}
}