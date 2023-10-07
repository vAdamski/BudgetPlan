using ApplicationUnitTests.Common;
using AutoMapper;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Services;
using BudgetPlan.Application.TransactionCategories.Queries.GetListTransactionCategories;
using BudgetPlan.Persistence;
using BudgetPlan.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace ApplicationUnitTests.TransactionCategories.Queries.GetListTransactionCategories;

[Collection("QueryCollection")]
public class GetListTransactionCategoriesQueryHandlerTests
{
    private readonly ICurrentUserService _currentUserService;
    private readonly BudgetPlanDbContext _context;
    private readonly IMapper _mapper;

    public GetListTransactionCategoriesQueryHandlerTests(QueryTestFixtures fixtures)
    {
        _context = fixtures.Context;
        _mapper = fixtures.Mapper;
        _currentUserService = fixtures.CurrentUserService;
    }

    [Fact]
    public async Task Handle_GetTransactionCategoryListViewModel_ShouldReturnValidTransactionCategoryListViewModel()
    {
        // Arrange
        var query = new GetListTransactionCategoriesQuery();
        var handler = new GetListTransactionCategoriesQueryHandler(_context, _currentUserService,
            new TransactionCategoryListViewModelFactory());

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var countOverTransactions = await _context
            .TransactionCategories.CountAsync(x =>
            x.CreatedBy == _currentUserService.Email &&
            x.StatusId == 1 &&
            x.OverTransactionCategoryId == null);

        result.ShouldNotBeNull();
        result.ShouldBeOfType<TransactionCategoryListViewModel>();
        result.OverTransactionCategoryList.ShouldNotBeNull();
        result.OverTransactionCategoryList.Count.ShouldBe(countOverTransactions);

        foreach (var overTransactionCategoryDto in result.OverTransactionCategoryList)
        {
            var countOfUnderTransactionCategories = await _context
                .TransactionCategories.CountAsync(x =>
                x.CreatedBy == _currentUserService.Email &&
                x.StatusId == 1 &&
                x.OverTransactionCategoryId == overTransactionCategoryDto.Id);
            
            overTransactionCategoryDto.TransactionCategoryDtos.ShouldNotBeNull();
            overTransactionCategoryDto.TransactionCategoryDtos.Count.ShouldBe(countOfUnderTransactionCategories);
        }
    }
}