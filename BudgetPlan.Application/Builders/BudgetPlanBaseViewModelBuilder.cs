using BudgetPlan.Application.Common.Interfaces.Builders;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Builders;

public class BudgetPlanBaseViewModelBuilder(
	IBudgetPlanBaseRepository budgetPlanBaseRepository,
	IBudgetPlanRepository budgetPlanRepository,
	ITransactionDetailsRepository transactionDetailsRepository)
	: IBudgetPlanBaseViewModelBuilder
{
	public async Task<BudgetPlanBaseViewModel> Create(Guid budgetPlanBaseId,
		CancellationToken cancellationToken = default)
	{
		var budgetPlanBase = await GetBudgetPlanBase(budgetPlanBaseId, cancellationToken);

		var budgetPlan = await GetBudgetPlan(cancellationToken, budgetPlanBase);

		BudgetPlanBaseViewModel vm = new();

		vm.BudgetPlanBaseId = budgetPlanBase.Id;

		var categories = budgetPlan.TransactionCategories.Where(x => x.IsOverCategory && x.StatusId == 1).ToList();

		var subCategoryIds = categories.SelectMany(x => x.SubTransactionCategories.Where(x => x.StatusId == 1).Select(x => x.Id)).ToList();

		var days = ListDaysBetween(budgetPlanBase.DateFrom, budgetPlanBase.DateTo);

		List<TransactionDetail> transactionDetails =
			await transactionDetailsRepository.GetTransactionsForCategoriesBetweenDaysAsync(subCategoryIds,
				budgetPlanBase.DateFrom, budgetPlanBase.DateTo, cancellationToken);

		foreach (var category in categories)
		{
			List<SubTransactionCategoryDetailsViewDto> subCategorieDtosList = new();

			var subCategories = category.SubTransactionCategories;

			foreach (var subCategory in subCategories)
			{
				var budgetPlanDetail =
					budgetPlanBase.BudgetPlanDetailsList.First(x => x.TransactionCategoryId == subCategory.Id);

				List<TransactionItemsPerDayDto> transactionItemsPerDayDtos = new();

				foreach (var day in days)
				{
					var transactionDetailsPerDayAndCategory = transactionDetails.Where(x =>
							x.TransactionCategoryId == subCategory.Id &&
							x.TransactionDate == day)
						.ToList();

					TransactionItemsPerDayDto transactionItemsPerDayDto = new TransactionItemsPerDayDto
					{
						Date = day,
						TransactionItemDtos = transactionDetailsPerDayAndCategory.Select(x => new TransactionItemDto(x))
							.ToList()
					};

					transactionItemsPerDayDtos.Add(transactionItemsPerDayDto);
				}

				var budgetPlanDetailsViewDto = new BudgetPlanDetailsViewDto
				{
					Id = budgetPlanDetail.Id,
					AmountAllocated = budgetPlanDetail.ExpectedAmount,
					TransactionItemsForDaysDtos = transactionItemsPerDayDtos
				};

				var subCategoryDto = new SubTransactionCategoryDetailsViewDto
				{
					SubCategoryId = subCategory.Id,
					SubCategoryName = subCategory.TransactionCategoryName,
					BudgetPlanDetailsDto = budgetPlanDetailsViewDto
				};

				subCategorieDtosList.Add(subCategoryDto);
			}

			var transactionCategoryDto = new TransactionCategoryDetailsViewDto()
			{
				TransactionCategoryName = category.TransactionCategoryName,
				TransactionType = category.TransactionType,
				SubTransactionCategoryDetailsViewDtos = subCategorieDtosList
			};

			vm.TransactionCategoryDetailsViewDtos.Add(transactionCategoryDto);
		}

		return vm;
	}

	private async Task<BudgetPlanEntity> GetBudgetPlan(CancellationToken cancellationToken,
		BudgetPlanBase budgetPlanBase)
	{
		return await budgetPlanRepository.GetByIdAsync(budgetPlanBase.BudgetPlanEntityId, cancellationToken);
	}

	private async Task<BudgetPlanBase> GetBudgetPlanBase(Guid budgetPlanBaseId, CancellationToken cancellationToken)
	{
		var budgetPlanBase =
			await budgetPlanBaseRepository.GetWithBudgetPlanDetailsByIdAsync(budgetPlanBaseId, cancellationToken);
		return budgetPlanBase;
	}

	private List<DateOnly> ListDaysBetween(DateOnly dateFrom, DateOnly dateTo)
	{
		var days = new List<DateOnly>();
		for (var date = dateFrom; date <= dateTo; date = date.AddDays(1))
		{
			days.Add(date);
		}

		return days;
	}
}