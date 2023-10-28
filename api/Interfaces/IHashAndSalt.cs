using api.Models;

namespace api.Interfaces;

public interface IHashAndSalt
{
     public Task<Hash?> CreatHash(string Userpassword, byte[] saltKay);
}
