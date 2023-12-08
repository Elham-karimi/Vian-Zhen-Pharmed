namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<LoggedInDto?> CreateAsync(RegisterDto userInput, CancellationToken cancellationToken);

    public Task<LoggedInDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken);

    public Task<UpdateResult?> UpdateAsync(string userId, AppUser appUser,CancellationToken cancellationToken);

    public Task<DeleteResult?> DeleteAsync(string userId, CancellationToken cancellationToken);
}
