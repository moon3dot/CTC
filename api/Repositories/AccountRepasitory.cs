using System.Security.Cryptography;
using System.Text;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
     public class AccountRepository
     {
          private const string _collectionName = "users";
          private readonly IMongoCollection<Customer>? _collection;
          private readonly IHashAndSalt _hashSaltRepository;

          public AccountRepository(IMongoClient client, IMongoDbSettings DbSettings, IHashAndSalt hashSaltRepository)
          {
               var database = client.GetDatabase(DbSettings.DatabaseName);
               _collection = database.GetCollection<Customer>(_collectionName);
               _hashSaltRepository = hashSaltRepository;
          }

          public async Task<UserDto?> CreateAsyncCustomer(RegisterDto userInput, CancellationToken cancellationToken)
          {
               bool doesAccountExist = await _collection.Find<Customer>(User =>
                   userInput.Phone == userInput.Phone.ToLower().Trim()).AnyAsync(cancellationToken);

               if (doesAccountExist)
                    return null;

               Hash? passwordHashed = _hashSaltRepository.CreatHash(userInput, cancellationToken);

               if (passwordHashed is null)
                    return null;

               Customer customer = new Customer(
                   Id: null,
                   Phone: userInput.Phone.ToLower().Trim(),
                   FullName: userInput.FullName.ToLower().Trim(),
                   FinalPassword: passwordHashed.Password,
                   SaltKey: passwordHashed.Salt
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
     }

}