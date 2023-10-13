namespace api.Interfaces;

public interface IAdminRepository
{
    public Task<IEnumerable<AppUser>> GetAll(CancellationToken cancellationToken);

    public Task<AppUser> Get(string userId, CancellationToken cancellationToken);
}
