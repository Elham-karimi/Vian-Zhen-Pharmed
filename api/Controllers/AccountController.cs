namespace api.Controllers;

public class AccountController(IAccountRepository _accountRepository) : BaseApiController
{
    /// <summary>
    /// Create Accounts
    /// Concurrenapi/Controllers/AccountController.cs"userInput"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>UserDto</returns>
    [HttpPost("register")]
    public async Task<ActionResult<LoggedInDto>> Register(RegisterDto userInput, CancellationToken cancellationToken)
    {
        if (userInput.Password != userInput.ConfirmPassword)
            return BadRequest("Passwords don't match!");

        LoggedInDto? loggedInDto = await _accountRepository.CreateAsync(userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("Email/Username is taken.");

        return loggedInDto;
    }

    /// <summary>
    /// Login Accounts
    /// Concurrency => async is used
    /// </summary>
    /// <param name="userInput"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>UserDto</returns>
    [HttpPost("login")]
    public async Task<ActionResult<LoggedInDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    {
        LoggedInDto? loggedInDto = await _accountRepository.LoginAsync(userInput, cancellationToken);

        if (loggedInDto is null)
            return Unauthorized("Wrong username or password");

        return loggedInDto;
    }

    /// <summary>
    /// Update Accounts
    /// Concurrency => async is used
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="registerDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>UpdateResult</returns>
    [HttpPut("update/{userId}")]
    public async Task<ActionResult<UpdateResult?>> UpdateUserById(string userId, RegisterDto userInput, CancellationToken cancellationToken)
    {
        // if (userInput.Password != userInput.ConfirmPassword)
        //     return BadRequest("Password don't match!");

        UpdateResult? updateResult = await _accountRepository.UpdateAsync(userId, userInput, cancellationToken);

        return updateResult;
    }

    /// <summary>
    /// Delete Accounts
    /// Concurrency => async is used
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>DeleteResult</returns>
    [HttpDelete("delete/{userId}")]
    public async Task<ActionResult<DeleteResult?>> DeleteUserById(string userId, CancellationToken cancellationToken)
    {
        DeleteResult? deleteResult = await _accountRepository.DeleteAsync(userId, cancellationToken);

        return deleteResult;
    }
}
