namespace api.Interfaces;

public interface IAccountRepasitory
{
public  Task<UserDto> CreatUserAccount(RegisterDto userInput, CancellationToken cancellationToken);    
}
