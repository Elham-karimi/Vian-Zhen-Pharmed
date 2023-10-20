namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<UserDto?> CreateAsync(RegisterDto userInput, CancellationToken cancellationToken);

    public Task<UserDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken);

    public Task<UpdateResult?> UpdateAsync(string userId, RegisterDto registerDto,CancellationToken cancellationToken);

    public Task<DeleteResult?> DeleteAsync(string userId, CancellationToken cancellationToken);
}
