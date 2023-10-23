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
          UserDto? userDto = await _accountRepasitory.CreatAsyncCustomer(userInput, cancellationToken);

          if (userDto is null)
               return BadRequest("Email/Username is taken.");

          return userDto;
     }

     [HttpPost("login")]

     public async Task<ActionResult<UserDto>> Login(RegisterDto userinput, CancellationToken cancellationToken)
     {
          UserDto? userDto = await _accountRepasitory.LoginAsyncCustomer(userinput, cancellationToken);

          if (userDto is null)
               return Unauthorized("Wrong username or password");

          return userDto;
     }
}
