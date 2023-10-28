using api.Models;

namespace api.Interfaces;

public interface IHashAndSalt
{
     public Hash? CreatHash(RegisterDto passwordHash , CancellationToken cancellationToken);
}
