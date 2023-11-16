
namespace api.Interfaces;

public interface ICityRepository
{
    public Task<City?> CreateAsync(City userInput, CancellationToken cancellationToken);

    public Task<City?> GetByNameAsync (string cityName, CancellationToken cancellationToken);

    public Task<List<City>> GetAllAsync (CancellationToken cancellationToken);
}
