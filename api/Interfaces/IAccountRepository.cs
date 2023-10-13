namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<UserDto?> Create(RegisterDto userInput, CancellationToken cancellationToken);

    public Task<UserDto?> Login(LoginDto userInput, CancellationToken cancellationToken);

    public Task<UpdateResult?> Update(string userId, RegisterDto registerDto,CancellationToken cancellationToken);

    public Task<DeleteResult?> Delete(string userId, CancellationToken cancellationToken);
}
