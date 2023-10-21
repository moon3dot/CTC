namespace api.Repositories;

public class AccountRepasitory
{
     #region golobal var
     private const string _collectionName = "users"; //global var for using 
     private readonly IMongoCollection<Customer>? _collection; //global var for using find & ..
     #endregion

     #region  inject Imongo to repasitory
     public AccountRepasitory(IMongoClient client, IMongoDbSettings DbSettings)
     {
          var database = client.GetDatabase(DbSettings.DatabaseName);
          _collection = database.GetCollection<Customer>(_collectionName);
     }
     #endregion
     public async Task<CustomerUser?> CreatCustomerAccount(RegisterDto userInput, CancellationToken cancellationToken)
     {
          bool doesAccountExist = await _collection.Find<Customer>(User =>
           userInput.Phone == userInput.Phone.ToLower().Trim()).AnyAsync(cancellationToken);

          if (doesAccountExist)
               return null;

          Customer customer = new Customer(
               Id: null,
               Phone: userInput.Phone,
               FullName: userInput.FullName,
               Password: userInput.Password,
               VerificationCode: userInput.VerificationCode
          );
          if (_collection is not null)
               await _collection.InsertOneAsync(customer, null, cancellationToken);

          if (customer.Id is not null)
          {
               CustomerUser customerUser = new CustomerUser(
                    Id: customer.Id,
                    FullName: customer.FullName
               );
               return customerUser;
          }
          return null;
     }
}
