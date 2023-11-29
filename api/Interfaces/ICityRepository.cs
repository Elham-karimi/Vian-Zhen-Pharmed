
namespace api.Interfaces;

public interface ICityRepository
{
    public Task<City?> CreateAsync(CityDto userInput, CancellationToken cancellationToken);

    public Task<City?> GetByNameAsync (string stateName, CancellationToken cancellationToken);

    public Task<List<City>> GetAllAsync (CancellationToken cancellationToken);
}
