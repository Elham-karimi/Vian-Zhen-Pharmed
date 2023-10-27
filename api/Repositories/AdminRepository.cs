namespace api.Repositories;

public class AdminRepository : IAdminRepository
{
    private const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;

    public AdminRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>(_collectionName);
    }

    public async Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<AppUser> appUsers = await _collection.Find<AppUser>(new BsonDocument()).ToListAsync(cancellationToken);

        List<UserDto> userDtos = new List<UserDto>();

        if (appUsers.Any())
        {
            foreach (AppUser appUser in appUsers)
            {
                UserDto userDto = new UserDto(
                    Id: appUser.Id!,
                    Email: appUser.Email
                );

                userDtos.Add(userDto);
            }

            return userDtos;
        }

        return userDtos;
    }

    public async Task<UserDto?> GetَUserbyIdAsync(string userId, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(user => user.Id == userId).FirstOrDefaultAsync(cancellationToken);

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
}