using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/transactionDetails")]
public class TransactionDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddTransactionDetail()
    {
        throw new NotImplementedException();
    }
}