namespace api.Repositories;

public class CityRepository : ICityRepository
{
    private const string _collectionName = "cities";

    private readonly IMongoCollection<City> _collection;

    public CityRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<City>(_collectionName);
    }

    public async Task<City?> CreateAsync(City userInput, CancellationToken cancellationToken)
    {
        bool doseCityExist = await _collection.Find<City>(city =>
        city.StateName == userInput.StateName.ToLower().Trim()).AnyAsync(cancellationToken);

        if (doseCityExist)
            return null;

        City city = new City(
         Id: null,
         StateName: userInput.StateName
     );

        if (_collection is not null)
            await _collection.InsertOneAsync(city, null, cancellationToken);

        return city;
    }
}
