using api.Models;

namespace api.Interfaces;

public interface IHashAndSalt
{
     public Hash? CreatHash(string userPassword, Hash passwodHash);
}
