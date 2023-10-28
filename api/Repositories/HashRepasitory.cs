using System.Security.Cryptography;
using System.Text;
using api.Interfaces;
using api.Models;

namespace api.Repoitories;

public class HashRepasitory
{
    /// <summary>
    /// for hash password user and send for accountRepasitory
    /// </summary>
    /// <param name="userInput"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Hash model by var name password_and_Salt
    /// </returns>
    public Hash? CreatHash(RegisterDto userInput, CancellationToken cancellationToken)
    {
        using var hmac = new HMACSHA512();

        if (userInput is null)
            return null;

        return new Hash(
           Password: hmac.ComputeHash(Encoding.UTF8.GetBytes(userInput.Password)),
           Salt: hmac.Key
        );
    }
}
