using api.Controllers.helpers;
using api.Interfaces;

namespace api.Controllers;

public class AccountController : BaseApiController
{
     private readonly IAccountRepasitory _accountRepasitory;

     public AccountController(IAccountRepasitory accountRepasitory)
     {

          _accountRepasitory = accountRepasitory;
     }

     [HttpPost("register")]
     public async Task<ActionResult<UserDto>> Register(RegisterDto userInput, CancellationToken cancellationToken)
     {
          UserDto? userDto = await _accountRepasitory.CreatUserAccount(userInput, cancellationToken);

          if (userDto is null)
               return BadRequest("Email/Username is taken.");

          return userDto;
     }
}
