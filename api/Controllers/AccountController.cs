using api.Controllers.helpers;

namespace api.Controllers;

public class AccountController : BaseApiController
{
    [HttpPost("RegisterCustomer")]
    public async Task<AcceptedResult<CustomerUser>>
}
