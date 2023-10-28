using System.Security.Cryptography;
using System.Text;
using api.Interfaces;
using api.Models;

namespace api.Repositories;

public class HashSaltRepasitory : IHashAndSalt
{
    public Hash? CreatHash(string userPassword, Hash passwordHash)
    {
        using var hmac = new HMACSHA512();

        if (userPassword is null)
            return null;

        Hash creatHash = new Hash(
           PasswordHash: hmac.ComputeHash(Encoding.UTF8.GetBytes(userPassword)),
           Salt: hmac.Key
        );
        return creatHash;
    }
}
