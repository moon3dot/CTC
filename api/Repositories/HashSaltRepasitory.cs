using System.Security.Cryptography;
using System.Text;
using api.Interfaces;
using api.Models;

namespace api.Repositories;

public class HashSaltRepasitory
{
    public Hash? CreatHash(RegisterDto passwordHash)
    {
        using var hmac = new HMACSHA512();

        if (passwordHash is null)
            return null;

        Hash userPasswordHashed = new Hash(
           Password: hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordHash.Password)),
           Salt: hmac.Key
        );
        return userPasswordHashed;
    }
}
