namespace api.Interfaces;

public interface IAccountRepasitory
{
public  Task<RegisterDto> CreatUserAccount(RegisterDto userInput, CancellationToken cancellationToken);    
}
