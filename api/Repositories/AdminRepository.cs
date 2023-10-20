namespace api.Repositories;

public class AdminRepository : IAdminRepository
{
    private const string _collectionName = "users";
    private readonly IMongoCollection<Models.UserDto>? _collection;

    public AdminRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Models.UserDto>(_collectionName);
    }

    public async Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<UserDto> appUsers = await _collection.Find<UserDto>(new BsonDocument()).ToListAsync(cancellationToken);

        return appUsers;
    }

    public async Task<UserDto> GetUserbyIdAsync(string userId, CancellationToken cancellationToken)
    {
        UserDto appUser = await _collection.Find<UserDto>(user => user.Id == userId).FirstOrDefaultAsync(cancellationToken);

        return appUser;
    }
}
