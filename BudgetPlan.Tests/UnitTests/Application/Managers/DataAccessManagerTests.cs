using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Managers;
using BudgetPlan.Domain.Exceptions;
using BudgetPlan.Persistence;
using BudgetPlan.Persistence.Respositories;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;
using BudgetPlan.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Tests.UnitTests.Application.Managers;

public class DataAccessManagerTests : CommandTestBase
{
	private readonly BudgetPlanDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public DataAccessManagerTests() : base()
	{
		_context = _contextMock.Object;
		_currentUserService = _currentUserServiceMock.Object;
	}

	[Fact]
	public async Task GetDataAccessesListForCurrentUserAsync_ShouldReturnAccessesListViewModel()
	{
		// Arrange

		BudgetPlanRepository budgetPlanRepository =
			new BudgetPlanRepository(_context, _currentUserService);

		var dataAccessRepository =
			new DataAccessRepository(_context, _currentUserService);

		var dataAccessManager = new DataAccessManager(budgetPlanRepository, dataAccessRepository);

		// Act
		var result = await dataAccessManager.GetDataAccessesListForCurrentUserAsync(CancellationToken.None);

		// Assert
		result.ShouldNotBeNull();
		result.ShouldBeOfType<AccessesListViewModel>();
		result.AccessDetails.Count.ShouldBe(2);
	}
	
	[Fact]
	public async Task GetDataAccessForBudgetPlan_GivenValidBudgetPlanId_ShouldReturnDataAccessBudgetPlanViewModel()
	{
		// Arrange
		BudgetPlanRepository budgetPlanRepository =
			new BudgetPlanRepository(_context, _currentUserService);

		var dataAccessRepository =
			new DataAccessRepository(_context, _currentUserService);

		var dataAccessManager = new DataAccessManager(budgetPlanRepository, dataAccessRepository);

		var budgetPlanId = await _context.BudgetPlanEntities
			.Select(x => x.Id)
			.FirstOrDefaultAsync();

		// Act
		var result = await dataAccessManager.GetDataAccessForBudgetPlan(budgetPlanId, CancellationToken.None);

		// Assert
		result.ShouldNotBeNull();
		result.ShouldBeOfType<DataAccessBudgetPlanViewModel>();
		result.AccessedItems.Count.ShouldBe(1);
		result.AccessedItems.First().Email.ShouldBe("user@test.com");
	}
	
	[Fact]
	public async Task GetDataAccessForBudgetPlan_GivenInvalidBudgetPlanId_ShouldThrowNotFoundException()
	{
		// Arrange
		BudgetPlanRepository budgetPlanRepository =
			new BudgetPlanRepository(_context, _currentUserService);

		var dataAccessRepository =
			new DataAccessRepository(_context, _currentUserService);

		var dataAccessManager = new DataAccessManager(budgetPlanRepository, dataAccessRepository);

		// Act & Assert
		await Should.ThrowAsync<NotFoundException>(async () =>
			await dataAccessManager.GetDataAccessForBudgetPlan(Guid.NewGuid(), CancellationToken.None));
	}

	[Fact]
	public async Task UpdateDataAccess_GivenValidRequest_ShouldUpdateDataAccess()
	{
		// Arrange
		BudgetPlanRepository budgetPlanRepository =
			new BudgetPlanRepository(_context, _currentUserService);

		var dataAccessRepository =
			new DataAccessRepository(_context, _currentUserService);

		var dataAccessManager = new DataAccessManager(budgetPlanRepository, dataAccessRepository);

		var dataAccessId = await _context.DataAccesses
			.Select(x => x.Id)
			.FirstOrDefaultAsync();

		var updateViewModel = new UpdateDataAccessViewModel
		{
			AccessId = dataAccessId,
			AccessPersonDtos = new List<UpdateDataAccessItemDto>()
			{
				new()
				{
					Email = "user@test.com"
				},
				new()
				{
					Email = "user2@test.com"
				}
			}
		};

		// Act
		await dataAccessManager.UpdateDataAccess(dataAccessId, updateViewModel, CancellationToken.None);

		// Assert
		var objectToValidate = await _context.DataAccesses
			.Include(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x => x.Id == dataAccessId);
		
		objectToValidate.ShouldNotBeNull();
		objectToValidate.AccessedPersons.Count.ShouldBe(2);
		objectToValidate.AccessedPersons.Any(x => x.Email == "user@test.com").ShouldBeTrue();
		objectToValidate.AccessedPersons.Any(x => x.Email == "user2@test.com").ShouldBeTrue();
	}

	[Theory]
	[InlineData("egebege")]
	[InlineData("egebege@")]
	[InlineData("egebege@.com")]
	[InlineData("egebege.com")]
	[InlineData("")]
	public async Task UpdateDataAccess_GivenInvalidRequest_ShouldThrowInvalidEmailException(string email)
	{
		// Arrange
		BudgetPlanRepository budgetPlanRepository =
			new BudgetPlanRepository(_context, _currentUserService);

		var dataAccessRepository =
			new DataAccessRepository(_context, _currentUserService);

		var dataAccessManager = new DataAccessManager(budgetPlanRepository, dataAccessRepository);

		var dataAccessId = await _context.DataAccesses
			.Select(x => x.Id)
			.FirstOrDefaultAsync();
		
		var updateViewModel = new UpdateDataAccessViewModel
		{
			AccessId = dataAccessId,
			AccessPersonDtos = new List<UpdateDataAccessItemDto>()
			{
				new()
				{
					Email = email
				},
			}
		};
		
		// Act & Assert
		await Should.ThrowAsync<InvalidEmailException>(async () =>
			await dataAccessManager.UpdateDataAccess(dataAccessId, updateViewModel, CancellationToken.None));
	}
}