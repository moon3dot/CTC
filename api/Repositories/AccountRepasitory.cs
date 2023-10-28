using System.Security.Cryptography;
using System.Text;
using api.Interfaces;
using api.Models;

namespace api.Repositories;

public class AccountRepasitory
{
     #region golobal var
     private const string _collectionName = "users"; //global var for using 
     private readonly IMongoCollection<Customer>? _collection; //global var for using find & ..
     private readonly IHashAndSalt _hashSaltRepository;
     #endregion

     #region  inject Imongo to repasitory
     public AccountRepasitory(IMongoClient client, IMongoDbSettings DbSettings, IHashAndSalt hashSaltRepository)
     {
          var database = client.GetDatabase(DbSettings.DatabaseName);
          _collection = database.GetCollection<Customer>(_collectionName);
          _hashSaltRepository = hashSaltRepository;
     }
     #endregion
     public async Task<UserDto?> CreatAsyncCustomer(RegisterDto userInput, CancellationToken cancellationToken)
     {
          bool doesAccountExist = await _collection.Find<Customer>(User =>
           userInput.Phone == userInput.Phone.ToLower().Trim()).AnyAsync(cancellationToken);

          if (doesAccountExist)
               return null;

          var hashSalt = await _hashSaltRepository.CreatHash(userInput.Password, new byte[0]);

          Customer customer = new Customer(
               Id: null,
               Phone: userInput.Phone.ToLower().Trim(),
               FullName: userInput.FullName.ToLower().Trim(),
               PasswordHash: hashSalt!.PasswordHash,
               SaltKey: hashSalt.SaltKey
          );

          if (_collection is not null)
               await _collection.InsertOneAsync(customer, null, cancellationToken);

          if (customer.Id is not null)
          {
               UserDto customerUser = new UserDto(
                    Id: customer.Id,
                    FullName: customer.FullName
               );
               return customerUser;
          }
          return null;
     }

     // public async Task<UserDto?> LoginAsyncCustomer(RegisterDto userinput, CancellationToken cancellationToken)
     // {
     //      Customer customer = await _collection.Find<Customer>(user => user.Phone == userinput.Phone.ToLower().Trim()).FirstOrDefaultAsync(cancellationToken);

     //      if (customer is null)
     //           return null;

     //      using var hmac = new HMACSHA512(customer.PasswordSalt!);

     //      var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userinput.Password));

     //      if (customer.PasswordHash is not null && customer.PasswordHash.SequenceEqual(ComputedHash))
     //      {
     //           if (customer.Id is not null)
     //           {
     //                return new UserDto(
     //                     Id: customer.Id,
     //                     FullName: customer.FullName
     //                );
     //           }
     //      }
     //      return null;
     // }
}
