using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Common.Validators;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Managers;

public class DataAccessManager(
	IBudgetPlanRepository budgetPlanRepository,
	IDataAccessRepository dataAccessRepository)
	: IDataAccessManager
{
	public async Task<AccessesListViewModel> GetDataAccessesListForCurrentUserAsync(CancellationToken cancellationToken = default)
	{
		var budgetPlans = await budgetPlanRepository.GetBudgetPlansForCurrentUserAsync(cancellationToken);

		AccessesListViewModel vm = new AccessesListViewModel(budgetPlans);

		return vm;
	}

	public async Task<DataAccessBudgetPlanViewModel> GetDataAccessForBudgetPlan(Guid budgetPlanId,
		CancellationToken cancellationToken = default)
	{
		var budgetPlan = await budgetPlanRepository.GetByIdAsync(budgetPlanId, cancellationToken);

		DataAccessBudgetPlanViewModel vm = new DataAccessBudgetPlanViewModel(budgetPlan);

		return vm;
	}

	public async Task UpdateDataAccess(Guid requestId, UpdateDataAccessViewModel requestViewModel,
		CancellationToken cancellationToken = default)
	{
		if (requestId.IsNullOrEmpty())
			throw new IdIsNullOrEmptyException();
		
		foreach (var accessPersonDto in requestViewModel.AccessPersonDtos)
		{
			if (!EmailValidator.IsValid(accessPersonDto.Email))
			    throw new InvalidEmailException(accessPersonDto.Email);
		}

		DataAccess dataAccess = await dataAccessRepository.GetById(requestId, cancellationToken);

		var accessedPersons = requestViewModel
			.AccessPersonDtos
			.Select(ap => new AccessedPerson(ap.Email))
			.ToList();

		dataAccess.OverrideAccessedPersons(accessedPersons);

		await dataAccessRepository.UpdateAsync(dataAccess, cancellationToken);
	}
}