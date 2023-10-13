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

    public async Task<UserDto?> Create(RegisterDto userInput, CancellationToken cancellationToken)
    {
        bool doesAccountExist = await _collection.Find<AppUser>(user =>
             user.Email == userInput.Email.ToLower().Trim()).AnyAsync(cancellationToken);

        if (doesAccountExist)
            return null;

        AppUser appUser = new AppUser(
            Id: null,
            Email: userInput.Email.ToLower().Trim(),
            Password: userInput.Password.Trim(),
            ConfirmPassword: userInput.ConfirmPassword.Trim(),
            City: userInput.City
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

    public async Task<UserDto?> Login(LoginDto userInput, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(user =>
        user.Email == userInput.Email.ToLower().Trim()
        && user.Password == userInput.Password).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

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

    public async Task<UpdateResult?> Update(string userId, RegisterDto userInput, CancellationToken cancellationToken)
    {
        var updatedUser = Builders<AppUser>.Update
        .Set((AppUser user) => user.Email, userInput.Email.ToLower().Trim())
        .Set(user => user.Password, userInput.Password.Trim())
        .Set(user => user.ConfirmPassword, userInput.ConfirmPassword.Trim())
        .Set(user => user.City, userInput.City);

        if (_collection is not null)
            return await _collection.UpdateOneAsync(userId, updatedUser, null, cancellationToken);

        return null;
    }

    public async Task<DeleteResult?> Delete(string userId, CancellationToken cancellationToken)
    {
        if (_collection is not null)
            return await _collection.DeleteOneAsync(userId, null, cancellationToken);

        return null;
    }

}
