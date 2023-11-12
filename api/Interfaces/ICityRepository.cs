
namespace api.Interfaces;

public interface ICityRepository
{
    public Task<City?> CreateAsync(City userInput, CancellationToken cancellationToken);
}
