namespace api.Interfaces;

public interface IAdminRepository
{
    public Task<List<AdminDto>> GetAllAsync(CancellationToken cancellationToken);

    public Task<AdminDto?> GetَUserbyIdAsync(string userId, CancellationToken cancellationToken);
}
