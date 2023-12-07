using System.Security.Cryptography;
using System.Text;

namespace api.Repositories;

public class AccountRepository : IAccountRepository
{
    private const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;

    public AccountRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>(_collectionName);
    }

    public async Task<UserDto?> CreateAsync(RegisterDto userInput, CancellationToken cancellationToken)
    {
        bool doesAccountExist = await _collection.Find<AppUser>(user =>
             user.Email == userInput.Email.ToLower().Trim()).AnyAsync(cancellationToken);

        if (doesAccountExist)
            return null;

        using var hmac = new HMACSHA512();

        AppUser appUser = new AppUser(
            Id: null,
            Email: userInput.Email.ToLower().Trim(),
            PasswordHash: hmac.ComputeHash(Encoding.UTF8.GetBytes(userInput.Password)),
            PasswordSalt: hmac.Key,
            City: new City(
                Id: null,
                StateName: userInput.City.StateName
            )
        );

        if (_collection is not null)
            await _collection.InsertOneAsync(appUser, null, cancellationToken);

        if (appUser.Id is not null)
        {
            UserDto userDto = new UserDto(
                Id: appUser.Id,
                Email: appUser.Email
            );

            return userDto;
        }

        return null;
    }

    public async Task<UserDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(user =>
        user.Email == userInput.Email.ToLower().Trim()).FirstOrDefaultAsync(cancellationToken);

        if(appUser is null)
           return null;

        using var hmac = new HMACSHA512(appUser.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userInput.Password));

        if (appUser.PasswordHash is not null && appUser.PasswordHash.SequenceEqual(computedHash))
        {
            if (appUser.Id is not null)
            {
                return new UserDto(
                    Id: appUser.Id,
                    Email: appUser.Email
                );
            }
        }

        return null;
    }

    public async Task<UpdateResult?> UpdateAsync(string userId, AppUser appUser, CancellationToken cancellationToken)
    {
        var updatedUser = Builders<AppUser>.Update
        .Set((AppUser user) => user.Email, appUser.Email.ToLower().Trim())
        .Set(user => user.PasswordHash, appUser.PasswordHash)
        .Set(user => user.PasswordSalt, appUser.PasswordSalt)
        .Set(user => user.City, appUser.City);

        if (_collection is not null)
            return await _collection.UpdateOneAsync(userId, updatedUser, null, cancellationToken);

        return null;
    }

    public async Task<DeleteResult?> DeleteAsync(string userId, CancellationToken cancellationToken)
    {
        if (_collection is not null)
            return await _collection.DeleteOneAsync(userId, null, cancellationToken);

        return null;
    }

}
