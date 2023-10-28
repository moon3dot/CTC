using System.Security.Cryptography;
using System.Text;
using api.Models;

namespace api.Repositories;

public class HashSaltRepasitory
{
    public Task<Hash?> CreatHash(string Userpassword, byte[] RSaltKay)
    {
        using var hmac = new HMACSHA512();

        if (Userpassword is not null)
        {
            Hash hash = new Hash(
              PasswordHash: hmac.ComputeHash(Encoding.UTF8.GetBytes(Userpassword)),
             SaltKey: hmac.Key
          ); 
          RSaltKay = hash.SaltKey;
          return Task.FromResult<Hash?>(hash);
        }

        return Task.FromResult<Hash?>(null);
    }

    
}
