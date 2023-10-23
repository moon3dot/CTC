namespace api.Interfaces;

public interface IAccountRepasitory
{
     public Task<UserDto?> CreatAsyncCustomer(RegisterDto userInput, CancellationToken cancellationToken);
     public Task<UserDto?> LoginAsyncCustomer(RegisterDto userinput, CancellationToken cancellationToken)
}
