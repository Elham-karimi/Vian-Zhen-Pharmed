namespace api.Interfaces;

public interface IAdminRepository
{
    public Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken);

    public Task<UserDto> GetَUserbyIdAsync(string userId, CancellationToken cancellationToken);
}
